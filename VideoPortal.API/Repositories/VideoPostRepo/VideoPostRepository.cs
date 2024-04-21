using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.VideoPostRepo
{
    public class VideoPostRepository : IVideoPostRepository
    {
        private readonly AppDbContext _context;

        public VideoPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id)
        {
            return await _context.VideoPosts
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<VideoPost>> GetAllVideoPostsWithCategoriesAsync()
        {
            return await _context.VideoPosts
                .Include(c => c.Categories)
                .ToListAsync();
        }




        public async Task<List<VideoPost>> SearchAsync(string searchString)
        {
            searchString = searchString?.Trim();

            if (string.IsNullOrEmpty(searchString))
            {
                return new List<VideoPost>();
            }

            // Normalize search string to lowercase for case-insensitive
            var searchLowercase = searchString.ToLower();

            return await _context.VideoPosts
                .Where(vp =>
                    // Check if the lowercased Title contains the word as a substring
                    vp.Title.ToLower().Contains(searchLowercase) ||
                    // Check if the lowercased shortDescription contains the word as a substring
                    (vp.ShortDescription != null && vp.ShortDescription.ToLower().Contains(searchLowercase))
                )
                .ToListAsync();
        }

    }
}

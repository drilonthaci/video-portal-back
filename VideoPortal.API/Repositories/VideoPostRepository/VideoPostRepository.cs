using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Data.Repositories.VideoPostRepository;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.VideoPostRepo
{
    public class VideoPostRepository : EntityBaseRepository<VideoPost>, IVideoPostRepository
    {

        public VideoPostRepository(AppDbContext context) : base(context){}

        public async Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id)
        {
            return await _context.VideoPosts
                .Include(c => c.Categories)
                .Include(vp => vp.VideoPostComments)
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

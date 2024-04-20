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

    }
}

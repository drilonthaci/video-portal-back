using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Models;
using VideoPortal.API.Repositories.Interface;

namespace VideoPortal.API.Repositories.Implementation
{
    public class VideoPostRepository : IVideoPostRepository
    {
        private readonly AppDbContext dbContext;

        public VideoPostRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<VideoPost> CreateAsync(VideoPost videoPost)
        {
            await dbContext.VideoPosts.AddAsync(videoPost);
            await dbContext.SaveChangesAsync();
            return videoPost;
        }

        public async Task<IEnumerable<VideoPost>> GetAllAsync()
        {
            return await dbContext.VideoPosts.Include(x => x.Categories).ToListAsync();
        }

        public async Task<VideoPost?> GetByIdAsync(Guid id)
        {
            return await dbContext.VideoPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

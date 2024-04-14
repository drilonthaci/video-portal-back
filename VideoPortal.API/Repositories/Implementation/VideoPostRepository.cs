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
    }
}

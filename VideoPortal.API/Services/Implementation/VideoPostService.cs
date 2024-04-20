using VideoPortal.API.Data;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Data.Repositories.VideoPostRepo;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Services.Interface;

namespace VideoPortal.API.Services.Implementation
{
    public class VideoPostService : EntityBaseRepository<VideoPost>, IVideoPostService
    {
        private readonly IVideoPostRepository _videoPostRepository;

        public VideoPostService(IVideoPostRepository videoPostRepository, AppDbContext context)
            : base(context)
        {

            _videoPostRepository = videoPostRepository;
        }

        public async Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id)
        {
            return await _videoPostRepository.GetVideoPostByIdWithCategoriesAsync(id);
        }

        public async Task<List<VideoPost>> GetAllVideoPostsWithCategoriesAsync()
        {
            return await _videoPostRepository.GetAllVideoPostsWithCategoriesAsync();
        }
    }
}

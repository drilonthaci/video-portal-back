using VideoPortal.API.Data;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Data.Repositories.VideoPostRepo;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Services.Interface;

namespace VideoPortal.API.Services.Implementation
{
    public class VideoPostService : IVideoPostService
    {
        private readonly IVideoPostRepository _videoPostRepository;

        public VideoPostService(IVideoPostRepository videoPostRepository)
            
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

        public async Task<List<VideoPost>> SearchAsync(string searchString)
        {
            return await _videoPostRepository.SearchAsync(searchString);
        }

        public async Task AddAsync(VideoPost videoPost)
        {
            await _videoPostRepository.AddAsync(videoPost);
        }

        public async Task UpdateAsync(VideoPost videoPost)
        {
            await _videoPostRepository.UpdateAsync(videoPost);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _videoPostRepository.DeleteAsync(id);
        }
    }
}

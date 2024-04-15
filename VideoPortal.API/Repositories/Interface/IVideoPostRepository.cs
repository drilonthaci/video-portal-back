using VideoPortal.API.Models;

namespace VideoPortal.API.Repositories.Interface
{
    public interface IVideoPostRepository
    {
        Task<VideoPost> CreateAsync(VideoPost videoPost);
        Task<IEnumerable<VideoPost>> GetAllAsync();
        Task<VideoPost?> GetByIdAsync(Guid id);
    }
}

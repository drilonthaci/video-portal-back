using VideoPortal.API.Models;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Repositories.Interface
{
    public interface IVideoPostRepository
    {
        Task<VideoPost> CreateAsync(VideoPost videoPost);
        Task<IEnumerable<VideoPost>> GetAllAsync();
        Task<VideoPost?> GetByIdAsync(Guid id);
        Task<VideoPost?> UpdateAsync(VideoPost videoPost);
        Task<VideoPost?> DeleteAsync(Guid id);
    }
}

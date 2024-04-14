using VideoPortal.API.Models;

namespace VideoPortal.API.Repositories.Interface
{
    public interface IVideoPostRepository
    {
        Task<VideoPost> CreateAsync(VideoPost videoPost);
    }
}

using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.VideoPostRepo
{
    public interface IVideoPostRepository
    {
        Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id);
        Task<List<VideoPost>> GetAllVideoPostsWithCategoriesAsync();
    }
}

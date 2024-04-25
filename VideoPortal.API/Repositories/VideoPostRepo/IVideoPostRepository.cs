using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.VideoPostRepo
{
    public interface IVideoPostRepository : IEntityBaseRepository<VideoPost>
    {
        Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id);
        Task<List<VideoPost>> GetAllVideoPostsWithCategoriesAsync();

        Task<List<VideoPost>> SearchAsync(string searchString);
    }
}

using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Services.Interface
{
    public interface IVideoPostService : IEntityBaseRepository<VideoPost>
    {
        Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id);
        Task<List<VideoPost>> GetAllVideoPostsWithCategoriesAsync();

        Task<List<VideoPost>> SearchAsync(string searchString);


    }
}

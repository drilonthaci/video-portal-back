using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Services.Interface
{
    public interface IVideoPostService : IEntityBaseRepository<VideoPost>
    {
        Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id);
    }
}

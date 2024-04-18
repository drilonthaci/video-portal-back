using VideoPortal.API.Models.Domain;
using VideoPortal.API.Data.Repositories.Base;

namespace VideoPortal.API.Services.Interface
{
    public interface ICategoryService : IEntityBaseRepository<Category>
    {
        Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id);
    }
}

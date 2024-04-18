using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Services.Interface
{
    public interface ICategoryService : IEntityBaseRepository<Category>
    {
        Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id);
    }
}

using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IEntityBaseRepository<Category>
    {
        Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id);


    }
}

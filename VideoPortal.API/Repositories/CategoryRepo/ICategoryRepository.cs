using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.CategoryRepo
{
    public interface ICategoryRepository : IEntityBaseRepository<Category>
    {
        Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id);


    }
}

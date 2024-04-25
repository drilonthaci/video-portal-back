using VideoPortal.API.Models.Domain;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Data.Repositories.CategoryRepo;

namespace VideoPortal.API.Services.Interface
{
    public interface ICategoryService 
    {
        Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid id);
    }

}

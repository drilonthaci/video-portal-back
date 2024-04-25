using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Services.CategoryService
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

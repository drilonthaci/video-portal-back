using VideoPortal.API.Models;

namespace VideoPortal.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category); 
    }
}

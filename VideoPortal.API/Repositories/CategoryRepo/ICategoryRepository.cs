using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.CategoryRepo
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id);
    }
}

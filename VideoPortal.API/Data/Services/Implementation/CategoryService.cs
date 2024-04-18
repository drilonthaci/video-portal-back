using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Data.Repositories.CategoryRepo;
using VideoPortal.API.Data.Services.Interface;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, AppDbContext context )
            : base(context)
        {
           
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id)
        {
            return await _categoryRepository.GetCategoryByIdWithVideoPostsAsync(id);
        }
    }
}

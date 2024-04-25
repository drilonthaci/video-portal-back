using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Data.Repositories.CategoryRepo;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Services.Interface;

namespace VideoPortal.API.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id)
        {
            return await _categoryRepository.GetCategoryByIdWithVideoPostsAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id)
        {
            return await _context.Categories
                .Include(c => c.VideoPosts)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

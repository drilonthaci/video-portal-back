using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.CategoryRepository
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(AppDbContext context) : base(context){}

        public async Task<Category> GetCategoryByIdWithVideoPostsAsync(Guid id)
        {
            return await _context.Categories
                .Include(c => c.VideoPosts)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

using VideoPortal.API.Data;
using VideoPortal.API.Models;
using VideoPortal.API.Repositories.Interface;

namespace VideoPortal.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        
        }
    }
}

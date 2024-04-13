using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var retrievedCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (retrievedCategory != null)
            {
                dbContext.Entry(retrievedCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }

            return null;
        }


        public async Task<Category?> DeleteAsync(Guid id)
        {
            var retrievedCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (retrievedCategory is null)
            {
                return null;
            }

            dbContext.Categories.Remove(retrievedCategory);
            await dbContext.SaveChangesAsync();
            return retrievedCategory;
        }
    }
}

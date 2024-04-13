﻿using Microsoft.EntityFrameworkCore;
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
    }
}
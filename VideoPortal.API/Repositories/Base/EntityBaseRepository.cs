using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Repositories.Base
{

    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }


        public async Task<IEnumerable<T>> GetAllVideoPostsWithCategoriesAsync()
        {
            return await _context.Set<T>()
                .Include(vp => (vp as VideoPost).Categories)
                .ToListAsync();
        }
    }
}

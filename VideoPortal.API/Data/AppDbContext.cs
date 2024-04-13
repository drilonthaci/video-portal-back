using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Models;

namespace VideoPortal.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<VideoPost> VideoPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

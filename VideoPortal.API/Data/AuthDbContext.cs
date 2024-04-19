using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VideoPortal.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var viewerRoleId = "1160e913-f2aa-4eb3-aa66-a4753d3ef777";
            var creatorRoleId = "7141b6d3-1348-4a18-9541-3708a8430e59";

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = viewerRoleId,
                    Name = "Viewer",
                    NormalizedName = "Viewer".ToUpper(),
                    ConcurrencyStamp = viewerRoleId
                },
                new IdentityRole()
                {
                    Id = creatorRoleId,
                    Name = "Creator",
                    NormalizedName = "Creator".ToUpper(),
                    ConcurrencyStamp = creatorRoleId
                }
            };

            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Create an admin User
            var adminUserId = "52b8ecd4-70db-48e1-9f30-75319625d923";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "life",
                Email = "admin@life.com",
                NormalizedEmail = "admin@life.com".ToUpper(),
                NormalizedUserName = "life".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Life@123@");

            builder.Entity<IdentityUser>().HasData(admin);

            // Give Roles To Admin
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = viewerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = creatorRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }

    }


    }


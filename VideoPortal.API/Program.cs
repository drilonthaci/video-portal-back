
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VideoPortal.API.Data;
using VideoPortal.API.Data.Repositories.VideoPostRepo;
using VideoPortal.API.Repositories.VideoPostCommentRepository;
using VideoPortal.API.Services.CategoryService;
using VideoPortal.API.Services.TokenService;
using VideoPortal.API.Services.VideoPostCommentService;
using VideoPortal.API.Services.VideoPostLikeService;
using VideoPortal.API.Services.VideoPostService;
using VideoPortal.API.Data.Repositories.CategoryRepository;
using VideoPortal.API.Repositories.VideoPostLikeRepository;
using VideoPortal.API.Data.Repositories.VideoPostRepository;

namespace VideoPortal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("VideoPortalConnectionString")
            ));

            builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("VideoPortalConnectionString")
         ));

            //Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IVideoPostService, VideoPostService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IVideoPostLikeService, VideoPostLikeService>();
            builder.Services.AddScoped<IVideoPostCommentService, VideoPostCommentService>();

            //Repositories
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IVideoPostRepository, VideoPostRepository>();
            builder.Services.AddScoped<IVideoPostLikeRepository, VideoPostLikeRepository>();
            builder.Services.AddScoped<IVideoPostCommentRepository, VideoPostCommentRepository>();



            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Life")
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });



            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        AuthenticationType = "Jwt",
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey =
                        new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });


        
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
                options.AllowAnyMethod();


            });

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Data.Repositories.CategoryRepo;
using VideoPortal.API.Data.Repositories.VideoPostRepo;
using VideoPortal.API.Services.Implementation;
using VideoPortal.API.Services.Interface;

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

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IVideoPostService, VideoPostService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IVideoPostRepository, VideoPostRepository>();


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


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
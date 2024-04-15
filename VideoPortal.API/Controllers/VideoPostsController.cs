using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Models;
using VideoPortal.API.Models.DTO;
using VideoPortal.API.Repositories.Interface;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoPostsController : ControllerBase
    {

        private readonly IVideoPostRepository videoPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public VideoPostsController(IVideoPostRepository videoPostRepository, ICategoryRepository categoryRepository)
        {
            this.videoPostRepository = videoPostRepository;
            this.categoryRepository = categoryRepository;
        }


        // POST: /api/videoposts
        [HttpPost]
        public async Task<IActionResult> CreateVideoPost([FromBody] CreateVideoPostRequestDto request)
        {
            var videoPost = new VideoPost
            {

                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                PublishedDate = request.PublishedDate,
                Publisher = request.Publisher,
                IsVisible = request.IsVisible,
                Categories = new List<Category>()
            };

            foreach (var categoryId in request.Categories)
            {
                var retreivedCategory = await categoryRepository.GetById(categoryId);
                if (retreivedCategory is not null)
                {
                    videoPost.Categories.Add(retreivedCategory);
                }
            }

            videoPost = await videoPostRepository.CreateAsync(videoPost);

            var response = new CreateVideoPostResponseDto
            {
                Id = videoPost.Id,
                Publisher = videoPost.Publisher,
                Content = videoPost.Content,
                ImageUrl = videoPost.ImageUrl,
                IsVisible = videoPost.IsVisible,
                PublishedDate = videoPost.PublishedDate,
                ShortDescription = videoPost.ShortDescription,
                Title = videoPost.Title,
                Categories = videoPost.Categories.Select(x => new CreateCategoryResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    ImageUrl = x.ImageUrl,
                }).ToList()
        };

            return Ok(response);
        }



        // GET: /api/videoposts
        [HttpGet]
        public async Task<IActionResult> GetAllVideoPosts()
        {
            var videoPosts = await videoPostRepository.GetAllAsync();

            // Domain model to DTO
            var response = new List<CreateVideoPostResponseDto>();
            foreach (var videoPost in videoPosts)
            {
                response.Add(new CreateVideoPostResponseDto
                {
                    Id = videoPost.Id,
                    Publisher = videoPost.Publisher,
                    Content = videoPost.Content,
                    ImageUrl = videoPost.ImageUrl,
                    IsVisible = videoPost.IsVisible,
                    PublishedDate = videoPost.PublishedDate,
                    ShortDescription = videoPost.ShortDescription,
                    Title = videoPost.Title,
                    Categories = videoPost.Categories.Select(x => new CreateCategoryResponseDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ShortDescription = x.ShortDescription,
                        ImageUrl = x.ImageUrl,
                    }).ToList()
                });
            }

            return Ok(response);
        }




        // GET: /api/videoposts/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetVideoPostById([FromRoute] Guid id)
        {
            var videoPost = await videoPostRepository.GetByIdAsync(id);

            if (videoPost is null)
            {
                return NotFound();
            }

            // Domain Model to DTO
            var response = new CreateVideoPostResponseDto
            {
                Id = videoPost.Id,
                Publisher = videoPost.Publisher,
                Content = videoPost.Content,
                ImageUrl = videoPost.ImageUrl,
                IsVisible = videoPost.IsVisible,
                PublishedDate = videoPost.PublishedDate,
                ShortDescription = videoPost.ShortDescription,
                Title = videoPost.Title,
                Categories = videoPost.Categories.Select(x => new CreateCategoryResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    ImageUrl = x.ImageUrl,
                }).ToList()
            };

            return Ok(response);
        }

    }
}

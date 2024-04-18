using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Models;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO;
using VideoPortal.API.Models.DTO.Category;
using VideoPortal.API.Models.DTO.VideoPost;
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
                VideoUrl = request.VideoUrl,
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
                Title = videoPost.Title,
                ShortDescription = videoPost.ShortDescription,
                Content = videoPost.Content,
                ImageUrl = videoPost.ImageUrl,
                VideoUrl = videoPost.VideoUrl,
                PublishedDate = videoPost.PublishedDate,
                Publisher = videoPost.Publisher,
                IsVisible = videoPost.IsVisible,
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
                    Title = videoPost.Title,
                    ShortDescription = videoPost.ShortDescription,
                    Content = videoPost.Content,
                    ImageUrl = videoPost.ImageUrl,
                    PublishedDate = videoPost.PublishedDate,
                    Publisher = videoPost.Publisher,
                    IsVisible = videoPost.IsVisible,
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
                Title = videoPost.Title,
                ShortDescription = videoPost.ShortDescription,
                Content = videoPost.Content,
                ImageUrl = videoPost.ImageUrl,
                VideoUrl = videoPost.VideoUrl,
                PublishedDate = videoPost.PublishedDate,
                Publisher = videoPost.Publisher,
                IsVisible = videoPost.IsVisible,
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




        // PUT: /videoposts/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateVideoPostById([FromRoute] Guid id, UpdateVideoPostRequestDto request)
        {
            // DTO to Domain Model
            var videoPost = new VideoPost
            {
                Id = id,
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                VideoUrl = request.VideoUrl,
                PublishedDate = request.PublishedDate,
                Publisher = request.Publisher,
                IsVisible = request.IsVisible,
                Categories = new List<Category>()
            };

            foreach (var categoryId in request.Categories)
            {
                var retreivedCategory = await categoryRepository.GetById(categoryId);

                if (retreivedCategory != null)
                {
                    videoPost.Categories.Add(retreivedCategory);
                }
            }

            // Call Repository To Update VideoPost Model
            var updatedVideoPost = await videoPostRepository.UpdateAsync(videoPost);

            if (updatedVideoPost == null)
            {
                return NotFound();
            }
            var response = new CreateVideoPostResponseDto
            {
                Id = videoPost.Id,
                Title = videoPost.Title,
                ShortDescription = videoPost.ShortDescription,
                Content = videoPost.Content,
                ImageUrl = videoPost.ImageUrl,
                VideoUrl = videoPost.VideoUrl,
                PublishedDate = videoPost.PublishedDate,
                Publisher = videoPost.Publisher,
                IsVisible = videoPost.IsVisible,
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



        // DELETE: videoposts/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteVideoPost([FromRoute] Guid id)
        {
            var deletedVideoPost = await videoPostRepository.DeleteAsync(id);

            if (deletedVideoPost == null)
            {
                return NotFound();
            }

            var response = new CreateVideoPostResponseDto
            {
                Id = deletedVideoPost.Id,
                Title = deletedVideoPost.Title,
                ShortDescription = deletedVideoPost.ShortDescription,
                Content = deletedVideoPost.Content,
                ImageUrl = deletedVideoPost.ImageUrl,
                VideoUrl = deletedVideoPost.VideoUrl,
                PublishedDate = deletedVideoPost.PublishedDate,
                Publisher = deletedVideoPost.Publisher,
                IsVisible = deletedVideoPost.IsVisible,
            };

            return Ok(response);
        }


    }
}

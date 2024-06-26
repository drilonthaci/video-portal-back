﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.Category;
using VideoPortal.API.Models.DTO.VideoPost;
using VideoPortal.API.Models.DTO.VideoPostComment;
using VideoPortal.API.Services.CategoryService;
using VideoPortal.API.Services.VideoPostService;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoPostsController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IVideoPostService _videoPostService;

        public VideoPostsController(ICategoryService categoryService, IVideoPostService videoPostService )
        {
            _categoryService = categoryService;
            _videoPostService = videoPostService;
        }



        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            try
            {
                var results = await _videoPostService.SearchAsync(searchString);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // POST: /api/videoposts
        [HttpPost]
      //  [Authorize(Roles = "Creator")]
        public async Task<IActionResult> AddVideoPost([FromBody] CreateVideoPostRequestDto request)
        {
            var videoPost = new VideoPost
            {

                Title = request.Title,
                ShortDescription = request.ShortDescription,
                ImageUrl = request.ImageUrl,
                VideoUrl = request.VideoUrl,
                PublishedDate = request.PublishedDate,
                Publisher = request.Publisher,
                Categories = new List<Category>()
            };

            foreach (var categoryId in request.Categories)
            {
                var retreivedCategory = await _categoryService.GetByIdAsync(categoryId);
                if (retreivedCategory is not null)
                {
                    videoPost.Categories.Add(retreivedCategory);
                }
            }

            await _videoPostService.AddAsync(videoPost);

            var response = new CreateVideoPostResponseDto
            {
                Id = videoPost.Id,
                Title = videoPost.Title,
                ShortDescription = videoPost.ShortDescription,
                ImageUrl = videoPost.ImageUrl,
                VideoUrl = videoPost.VideoUrl,
                PublishedDate = videoPost.PublishedDate,
                Publisher = videoPost.Publisher,
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
        //  [Authorize(Roles = "Creator")]
        public async Task<IActionResult> GetAllVideoPostsWithCategories()
        {
            var videoPosts = await _videoPostService.GetAllVideoPostsWithCategoriesAsync();

            if (videoPosts == null || !videoPosts.Any())
            {
                return NotFound();
            }

            var response = videoPosts.Select(videoPost => new CreateVideoPostResponseDto
            {
                Id = videoPost.Id,
                Title = videoPost.Title,
                ShortDescription = videoPost.ShortDescription,
                ImageUrl = videoPost.ImageUrl,
                VideoUrl = videoPost.VideoUrl,
                PublishedDate = videoPost.PublishedDate,
                Publisher = videoPost.Publisher,
                Categories = videoPost.Categories?.Select(category => new CreateCategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name
                }).ToList() ?? new List<CreateCategoryResponseDto>()
            }).ToList();

            return Ok(response);
        }



        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetVideoPostById([FromRoute] Guid id)
        {
            var videoPost = await _videoPostService.GetVideoPostByIdWithCategoriesAsync(id);

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
                ImageUrl = videoPost.ImageUrl,
                VideoUrl = videoPost.VideoUrl,
                PublishedDate = videoPost.PublishedDate,
                Publisher = videoPost.Publisher,
                Categories = videoPost.Categories?.Select(x => new CreateCategoryResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList() ?? new List<CreateCategoryResponseDto>(),

                 Comments = videoPost.VideoPostComments?.Select(co => new CreateCommentResponseDto
                 {
                     Id = co.Id,
                     UserEmail = co.UserEmail,
                     CommentText = co.CommentText,
                     CommentedAt = co.CommentedAt
                 }).ToList() ?? new List<CreateCommentResponseDto>()
            };

            return Ok(response);
        }





        // PUT: /videoposts/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Creator")]
        public async Task<IActionResult> UpdateVideoPostById([FromRoute] Guid id, UpdateVideoPostRequestDto request)
        {
            // DTO to Domain Model
            var videoPost = new VideoPost
            {
                Id = id,
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                ImageUrl = request.ImageUrl,
                VideoUrl = request.VideoUrl,
                PublishedDate = request.PublishedDate,
                Publisher = request.Publisher,
                Categories = new List<Category>()
            };

            foreach (var categoryId in request.Categories)
            {
                var retreivedCategory = await _categoryService.GetByIdAsync(categoryId);

                if (retreivedCategory != null)
                {
                    videoPost.Categories.Add(retreivedCategory);
                }
            }

            // Call Repository To Update VideoPost Model
             await _videoPostService.UpdateAsync(videoPost);

            var response = new CreateVideoPostResponseDto
            {
                Id = videoPost.Id,
                Title = videoPost.Title,
                ShortDescription = videoPost.ShortDescription,
                ImageUrl = videoPost.ImageUrl,
                VideoUrl = videoPost.VideoUrl,
                PublishedDate = videoPost.PublishedDate,
                Publisher = videoPost.Publisher,
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
        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Creator")]
        public async Task<IActionResult> DeleteVideoPost([FromRoute] Guid id)
        {
            await _videoPostService.DeleteAsync(id);

            return Ok();
        }


    }
}

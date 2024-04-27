using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoPortal.API.Models.DTO.VideoPostLike;
using VideoPortal.API.Services.VideoPostLikeService;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoPostLikeController : ControllerBase
    {
        private readonly IVideoPostLikeService _likeService;

        public VideoPostLikeController(IVideoPostLikeService likeService)
        {
            _likeService = likeService;
        }

        
        [HttpPost("like/{videoPostId}")]
        public async Task<IActionResult> LikeVideoPost(Guid videoPostId,  string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("User id is required.");

            var result = await _likeService.LikeVideoPostAsync(videoPostId, userId);

            if (result)
                return Ok();

            return BadRequest("User has already liked this post.");
        }


        [HttpGet("likes")]
        public async Task<IActionResult> GetUserLikes(string userId)
        {
            try
            {
                var likes = await _likeService.GetLikesByUserAsync(userId);
                return Ok(likes);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving user likes.");
            }
        }


        [HttpDelete("unlike/{videoPostId}")]
         public async Task<IActionResult> UnlikeVideoPost(Guid videoPostId, string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("User email is required.");
            
            var result = await _likeService.UnlikeVideoPostAsync(videoPostId, userId);

            if (result)
                return Ok();
            return BadRequest("User has not liked this post.");
        }
    }
}

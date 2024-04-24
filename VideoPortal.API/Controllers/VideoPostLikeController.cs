using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoPortal.API.Models.DTO.VideoPostLike;
using VideoPortal.API.Services.Interface;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoPostLikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public VideoPostLikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("like/{videoPostId}")]
        public async Task<IActionResult> LikeVideoPost(Guid videoPostId,  string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
                return BadRequest("User email is required.");

            var result = await _likeService.LikeVideoPostAsync(videoPostId, userEmail);

            if (result)
                return Ok();

            return BadRequest("User has already liked this post.");
        }


        [HttpGet("likes")]
        public async Task<IActionResult> GetUserLikes(string userEmail)
        {
            try
            {
                var likes = await _likeService.GetLikesByUserAsync(userEmail);
                return Ok(likes);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving user likes.");
            }
        }
        [HttpDelete("unlike/{videoPostId}")]
        public async Task<IActionResult> UnlikeVideoPost(Guid videoPostId, string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
                return BadRequest("User email is required.");

            var result = await _likeService.UnlikeVideoPostAsync(videoPostId, userEmail);

            if (result)
                return Ok();

            return BadRequest("User has not liked this post.");
        }



    }
}

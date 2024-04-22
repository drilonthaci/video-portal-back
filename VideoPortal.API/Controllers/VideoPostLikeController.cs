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


        [HttpPost("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddVideoPostLikeRequest addVideoPostLikeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _likeService.AddLikeAsync(addVideoPostLikeRequest.VideoPostId,
                addVideoPostLikeRequest.UserId);

            return Ok();
        }

        [HttpGet("user-likes/{userId}")]
        public async Task<IActionResult> GetUserLikesForAllVideoPosts(Guid userId)
        {
            var userLikes = await _likeService.GetLikesForUserAsync(userId);

            return Ok(userLikes);
        }

        [HttpDelete("Remove/{likeId}")]
        public async Task<IActionResult> RemoveLike(Guid likeId)
        {
            await _likeService.RemoveVideoLikeForUserAsync(likeId);

            return Ok();
        }

    }
}

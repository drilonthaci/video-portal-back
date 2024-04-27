using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Services.VideoPostCommentService;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoPostCommentsController : ControllerBase
    {
        private readonly IVideoPostCommentService _commentService;

       public VideoPostCommentsController(IVideoPostCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("comment/{videoPostId}")]
        public async Task<IActionResult> AddVideoPostComment(Guid videoPostId, string userId, string commentText)
        {
            var result = await _commentService.AddVideoPostCommentAsync(videoPostId, userId, commentText);

            if (result)
                return Ok();

            return StatusCode(500, "Failed to add comment.");
        }


        [HttpGet("comments")]
        public async Task<IActionResult> GetUserComments(string userId)
        {
            try
            {
                var likes = await _commentService.GetCommentsByUserAsync(userId);
                return Ok(likes);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving user likes.");
            }
        }


        [HttpDelete("comment/{videoPostId}")]
        public async Task<IActionResult> DeleteVideoPostComment(Guid videoPostId, string userId)
        {

            var result = await _commentService.DeleteVideoPostCommentAsync(videoPostId, userId);

            if (result)
                return Ok();

            return BadRequest("The comment does not exist.");
        }
    }
}

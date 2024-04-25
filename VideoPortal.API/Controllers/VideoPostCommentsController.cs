using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Services.Implementation;
using VideoPortal.API.Services.Interface;

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
        public async Task<IActionResult> AddVideoPostComment(Guid videoPostId, string userEmail, string commentText)
        {
            var result = await _commentService.AddVideoPostCommentAsync(videoPostId, userEmail, commentText);

            if (result)
                return Ok();

            return StatusCode(500, "Failed to add comment.");
        }


        [HttpGet("comments")]
        public async Task<IActionResult> GetUserComments(string userEmail)
        {
            try
            {
                var likes = await _commentService.GetCommentsByUserAsync(userEmail);
                return Ok(likes);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving user likes.");
            }
        }


        [HttpDelete("delete-comment/{videoPostId}")]
        public async Task<IActionResult> DeleteVideoPostComment(Guid videoPostId, string userEmail)
        {

            var result = await _commentService.DeleteVideoPostCommentAsync(videoPostId, userEmail);

            if (result)
                return Ok();

            return BadRequest("The comment does not exist.");
        }

    }
}

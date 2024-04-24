using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}

using VideoPortal.API.Repositories.CommentRepo;
using VideoPortal.API.Services.Interface;

namespace VideoPortal.API.Services.Implementation
{
    public class VideoPostCommentService : IVideoPostCommentService
    {
        private readonly IVideoPostCommentRepository _commentRepository;

        public VideoPostCommentService(IVideoPostCommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userEmail, string commentText)
        {
            return await _commentRepository.AddVideoPostCommentAsync(videoPostId, userEmail, commentText);
        }

    }
}

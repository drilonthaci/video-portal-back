using VideoPortal.API.Models.DTO.VideoPostComment;
using VideoPortal.API.Models.DTO.VideoPostLike;
using VideoPortal.API.Repositories.VideoPostCommentRepository;

namespace VideoPortal.API.Services.VideoPostCommentService
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

        public async Task<List<VideoPostCommentDto>> GetCommentsByUserAsync(string userEmail)
        {
            return await _commentRepository.GetCommentsByUserAsync(userEmail);
        }

        public async Task<bool> DeleteVideoPostCommentAsync(Guid videoPostId, string userEmail)
        {
            return await _commentRepository.DeleteVideoPostCommentAsync(videoPostId, userEmail);
        }

    }
}

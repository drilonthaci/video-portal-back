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
        public async Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userId, string commentText)
        {
            return await _commentRepository.AddVideoPostCommentAsync(videoPostId, userId, commentText);
        }

        public async Task<List<VideoPostCommentDto>> GetCommentsByUserAsync(string userId)
        {
            return await _commentRepository.GetCommentsByUserAsync(userId);
        }

        public async Task<bool> DeleteVideoPostCommentAsync(Guid videoPostId, string userId)
        {
            return await _commentRepository.DeleteVideoPostCommentAsync(videoPostId, userId);
        }
    }
}

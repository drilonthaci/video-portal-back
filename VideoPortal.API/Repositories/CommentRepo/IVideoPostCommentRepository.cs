using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostComment;

namespace VideoPortal.API.Repositories.CommentRepo
{
    public interface IVideoPostCommentRepository
    {
        Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userEmail, string commentText);
        Task<List<VideoPostCommentDto>> GetCommentsByUserAsync(string userEmail);

        Task<bool> DeleteVideoPostCommentAsync(Guid videoPostId, string userEmail);
    }
}

using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostComment;

namespace VideoPortal.API.Repositories.VideoPostCommentRepository
{
    public interface IVideoPostCommentRepository
    {
        Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userId, string commentText);
        Task<List<VideoPostCommentDto>> GetCommentsByUserAsync(string userId);
        Task<bool> DeleteVideoPostCommentAsync(Guid videoPostId, string userId); 
    }
}

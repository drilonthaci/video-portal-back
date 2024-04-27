using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;

namespace VideoPortal.API.Repositories.VideoPostLikeRepository
{
    public interface IVideoPostLikeRepository
    {
        Task<bool> LikeVideoPostAsync(Guid videoPostId, string userId);
        Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userID);
        Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userId);
    }
}

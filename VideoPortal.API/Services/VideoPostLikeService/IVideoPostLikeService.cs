using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;

namespace VideoPortal.API.Services.VideoPostLikeService
{
    public interface IVideoPostLikeService
    {
        Task<bool> LikeVideoPostAsync(Guid videoPostId, string userEmail);
        Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userEmail);
        Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userEmail);
    }
}

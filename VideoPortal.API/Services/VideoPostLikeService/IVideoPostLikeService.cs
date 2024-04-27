using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;

namespace VideoPortal.API.Services.VideoPostLikeService
{
    public interface IVideoPostLikeService
    {
        Task<bool> LikeVideoPostAsync(Guid videoPostId, string userId);
        Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userId);
        Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userId); 
    }
}

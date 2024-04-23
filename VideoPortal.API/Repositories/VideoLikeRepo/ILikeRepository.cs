using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;

namespace VideoPortal.API.Repositories.VideoLikeRepo
{
    public interface ILikeRepository
    {
        Task<bool> LikeVideoPostAsync(Guid videoPostId, string userEmail);
        Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userEmail);

    }
}

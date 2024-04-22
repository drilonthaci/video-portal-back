using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Repositories.VideoLikeRepo
{
    public interface ILikeRepository
    {
        Task AddLikeAsync(Guid videoPostId, Guid userId);
    }
}

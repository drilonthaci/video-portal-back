using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Repositories.VideoLikeRepo
{
    public interface ILikeRepository
    {
        Task AddLikeAsync(Guid videoPostId, Guid userId);
        Task<List<VideoPostLike>> GetLikesForUserAsync(Guid userId);

        Task RemoveVideoLikeForUserAsync(Guid likeId);

    }
}

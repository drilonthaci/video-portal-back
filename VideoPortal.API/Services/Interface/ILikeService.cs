using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Services.Interface
{
    public interface ILikeService
    {
        Task AddLikeAsync(Guid videoPostId, Guid userId);

        Task<List<VideoPostLike>> GetLikesForUserAsync(Guid userId);

        Task RemoveVideoLikeForUserAsync(Guid likeId);
    }
}

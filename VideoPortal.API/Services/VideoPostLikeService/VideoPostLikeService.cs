using VideoPortal.API.Models.DTO.VideoPostLike;
using VideoPortal.API.Repositories.VideoPostLikeRepository;

namespace VideoPortal.API.Services.VideoPostLikeService
{
    public class VideoPostLikeService : IVideoPostLikeService
    {
        private readonly IVideoPostLikeRepository _likeRepository;

        public VideoPostLikeService(IVideoPostLikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<bool> LikeVideoPostAsync(Guid videoPostId, string userId)
        {
            return await _likeRepository.LikeVideoPostAsync(videoPostId, userId);
        }

        public async Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userId)
        {
            return await _likeRepository.GetLikesByUserAsync(userId);
        }

        public async Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userEmail)
        {
            return await _likeRepository.UnlikeVideoPostAsync(videoPostId, userEmail);
        }
     

    }
}

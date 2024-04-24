using Microsoft.AspNetCore.Identity;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;
using VideoPortal.API.Repositories.VideoLikeRepo;
using VideoPortal.API.Services.Interface;

namespace VideoPortal.API.Services.Implementation
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public LikeService(ILikeRepository likeRepository, UserManager<IdentityUser> userManager)
        {
            _likeRepository = likeRepository;
            _userManager = userManager;
        }

        public async Task<bool> LikeVideoPostAsync(Guid videoPostId, string userEmail)
        {
            return await _likeRepository.LikeVideoPostAsync(videoPostId, userEmail);
        }

        public async Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userEmail)
        {
            return await _likeRepository.GetLikesByUserAsync(userEmail);
        }
        public async Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userEmail)
        {
            return await _likeRepository.UnlikeVideoPostAsync(videoPostId, userEmail);
        }


    }
}

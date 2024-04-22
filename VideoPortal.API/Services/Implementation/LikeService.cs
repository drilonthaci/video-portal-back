using Microsoft.AspNetCore.Identity;
using VideoPortal.API.Models.Domain;
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


          public async Task AddLikeAsync(Guid videoPostId, Guid userId)
              {
         await _likeRepository.AddLikeAsync(videoPostId, userId);
           }

      //  public async Task<List<VideoPostLike>> GetLikesForUserAsync(Guid userId)
        //{
          //  return await _likeRepository.GetLikesForUserAsync(userId);
        //}

        public async Task RemoveVideoLikeForUserAsync(Guid likeId)
        {
            await _likeRepository.RemoveVideoLikeForUserAsync(likeId);
        }


    }
}

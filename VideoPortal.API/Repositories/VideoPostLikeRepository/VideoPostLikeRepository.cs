using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;
using VideoPortal.API.Repositories.VideoPostLikeRepository;

namespace VideoPortal.API.Repositories.VideoPostLikeRepository
{
    public class VideoPostLikeRepository : IVideoPostLikeRepository
    {

        private readonly AppDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public VideoPostLikeRepository(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
           _userManager = userManager;

        }
   
        public async Task<bool> LikeVideoPostAsync(Guid videoPostId, string userId)
        {
           // Check if the user exists
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            // Check if the user has already liked this post
            var existingLike = await _context.VideoLikes
                .FirstOrDefaultAsync(l => l.VideoPostId == videoPostId && l.UserId == userId);

            if (existingLike == null)
            {
                var newLike = new VideoPostLike
                {
                    VideoPostId = videoPostId,
                    UserId = userId 
                };

                _context.VideoLikes.Add(newLike);
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // User has already liked this post
        }


        public async Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userId)
        {
            return await _context.VideoLikes
                .Where(vl => vl.UserId == userId) 
                .Select(vl => new UserLikeDto
                {
                    VideoPostId = vl.VideoPostId,
                    VideoPostName = vl.VideoPost.Title,
                    VideoUrl = vl.VideoPost.VideoUrl
                })
                .ToListAsync();
        }

        public async Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userId)
        {
            var existingLike = await _context.VideoLikes
                .FirstOrDefaultAsync(l => l.VideoPostId == videoPostId && l.UserId == userId);

            if (existingLike != null)
            {
                _context.VideoLikes.Remove(existingLike);
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // Like not found
        }


    }
}
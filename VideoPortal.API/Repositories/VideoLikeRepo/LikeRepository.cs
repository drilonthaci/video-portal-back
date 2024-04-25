using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;

namespace VideoPortal.API.Repositories.VideoLikeRepo
{
    public class LikeRepository : ILikeRepository
    {

        private readonly AppDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public LikeRepository(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<bool> LikeVideoPostAsync(Guid videoPostId, string userEmail)
        {
            var existingLike = await _context.VideoLikes
                .FirstOrDefaultAsync(l => l.VideoPostId == videoPostId && l.UserEmail == userEmail);

            if (existingLike == null)
            {
                var newLike = new VideoPostLike
                {
                    VideoPostId = videoPostId,
                    UserEmail = userEmail
                };

                _context.VideoLikes.Add(newLike);
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // User has already liked this post
        }

        public async Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userEmail)
        {
            return await _context.VideoLikes
                .Where(vl => vl.UserEmail == userEmail)
                .Select(vl => new UserLikeDto
                {
                    VideoPostId = vl.VideoPostId,
                    VideoPostName = vl.VideoPost.Title 
                })
                .ToListAsync();
        }


        public async Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userEmail)
        {
            var existingLike = await _context.VideoLikes
                .FirstOrDefaultAsync(l => l.VideoPostId == videoPostId && l.UserEmail == userEmail);

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

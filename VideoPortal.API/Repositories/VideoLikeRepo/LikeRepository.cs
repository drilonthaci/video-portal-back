using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Repositories.VideoLikeRepo
{
    public class LikeRepository : ILikeRepository
    {

        private readonly AppDbContext _context;

        public LikeRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddLikeAsync(Guid videoPostId, Guid userId)
        {
            var like = new VideoPostLike { Id = Guid.NewGuid(), VideoPostId = videoPostId,UserId = userId, };
            _context.VideoLikes.Add(like);
            await _context.SaveChangesAsync();
        }

      //  public async Task<List<VideoPostLike>> GetLikesForUserAsync(Guid userId)
        //{
          //  return await _context.VideoLikes
            //    .Include(l => l.VideoPost)
              //  .Where(l => l.UserId == userId)
                //.ToListAsync();
        //}

        public async Task RemoveVideoLikeForUserAsync(Guid likeId)
        {
            var like = await _context.VideoLikes.FindAsync(likeId);
            if (like != null)
            {
                _context.VideoLikes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }
    }
}

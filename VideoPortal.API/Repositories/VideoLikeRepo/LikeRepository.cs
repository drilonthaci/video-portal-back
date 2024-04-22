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

    }
}

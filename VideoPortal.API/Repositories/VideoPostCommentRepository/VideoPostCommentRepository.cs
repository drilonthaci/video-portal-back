using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostComment;
using VideoPortal.API.Repositories.VideoPostCommentRepository;

namespace VideoPortal.API.Repositories.VideoPostCommentRepository
{ 
    public class VideoPostCommentRepository : IVideoPostCommentRepository
    {

        private readonly AppDbContext _context;


        public VideoPostCommentRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userId, string commentText)
        {
            var newComment = new VideoPostComment
            {
                VideoPostId = videoPostId,
                UserId = userId,
                CommentText = commentText,
                CommentedAt = DateTime.UtcNow
            };

            _context.VideoPostComments.Add(newComment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<VideoPostCommentDto>> GetCommentsByUserAsync(string userId)
        {
            var comments = await _context.VideoPostComments
                .Include(c => c.VideoPost) 
                .Where(c => c.UserId == userId)
                .Select(c => new VideoPostCommentDto
                {
                    CommentId = c.Id,
                    CommentText = c.CommentText,
                    CommentedAt = c.CommentedAt,
                    VideoPostName = c.VideoPost.Title,
                    VideoUrl = c.VideoPost.VideoUrl
                })
                .ToListAsync();

            return comments;
        }

        public async Task<bool> DeleteVideoPostCommentAsync(Guid videoPostId, string userId)
        {
            var existingComment = await _context.VideoPostComments
                .FirstOrDefaultAsync(l => l.VideoPostId == videoPostId && l.UserId == userId);

            if (existingComment != null)
            {
                _context.VideoPostComments.Remove(existingComment);
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // Comment not found
        } 
    }
}

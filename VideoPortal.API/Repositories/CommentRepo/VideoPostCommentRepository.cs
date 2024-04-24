using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Repositories.CommentRepo
{ 
    public class VideoPostCommentRepository : IVideoPostCommentRepository
    {

        private readonly AppDbContext _context;


        public VideoPostCommentRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userEmail, string commentText)
        {
            var newComment = new VideoPostComment
            {
                VideoPostId = videoPostId,
                UserEmail = userEmail,
                CommentText = commentText,
                CommentedAt = DateTime.UtcNow
            };

            _context.VideoPostComments.Add(newComment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

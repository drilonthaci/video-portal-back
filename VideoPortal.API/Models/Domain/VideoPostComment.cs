using Microsoft.AspNetCore.Identity;

namespace VideoPortal.API.Models.Domain
{
    public class VideoPostComment
    {
        public Guid Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedAt { get; set; }

        public Guid VideoPostId { get; set; }
        public VideoPost VideoPost { get; set; }
        public string UserId { get; set; }

    }
}

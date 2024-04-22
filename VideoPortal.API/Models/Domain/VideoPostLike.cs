using Microsoft.AspNetCore.Identity;

namespace VideoPortal.API.Models.Domain
{
    public class VideoPostLike
    {
        public Guid Id { get; set; }
        public Guid VideoPostId { get; set; }
        public VideoPost VideoPost { get; set; }
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}

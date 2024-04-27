using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoPortal.API.Models.Domain
{
    public class VideoPostLike
    {
        public Guid Id { get; set; }
        public Guid VideoPostId { get; set; }
        public VideoPost VideoPost { get; set; }
        public string UserId { get; set; }
    }
}

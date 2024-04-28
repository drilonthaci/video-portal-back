
using System.Text.Json.Serialization;
using VideoPortal.API.Data.Repositories.Base;

namespace VideoPortal.API.Models.Domain
{
    public class VideoPost : IEntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Publisher { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<VideoPostLike> Likes { get; set; }
        public ICollection<VideoPostComment> VideoPostComments { get; set; }
    }
}

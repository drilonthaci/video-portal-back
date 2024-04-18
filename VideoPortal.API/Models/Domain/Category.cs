using VideoPortal.API.Data.Repositories.Base;

namespace VideoPortal.API.Models.Domain
{
    public class Category : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<VideoPost> VideoPosts { get; set; }
    }
}

namespace VideoPortal.API.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<VideoPost> VideoPosts { get; set; }
    }
}

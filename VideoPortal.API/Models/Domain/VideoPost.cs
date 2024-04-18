namespace VideoPortal.API.Models.Domain
{
    public class VideoPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Publisher { get; set; }
        public bool IsVisible { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}

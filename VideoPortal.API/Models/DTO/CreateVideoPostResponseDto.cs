namespace VideoPortal.API.Models.DTO
{
    public class CreateVideoPostResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Publisher { get; set; }
        public bool IsVisible { get; set; }

        public List<CreateCategoryResponseDto> Categories { get; set; } = new List<CreateCategoryResponseDto>();
    }
}

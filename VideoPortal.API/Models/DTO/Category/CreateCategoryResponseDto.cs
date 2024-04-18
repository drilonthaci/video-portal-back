namespace VideoPortal.API.Models.DTO.Category
{
    public class CreateCategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}

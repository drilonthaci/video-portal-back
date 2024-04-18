using VideoPortal.API.Models.DTO.VideoPost;

namespace VideoPortal.API.Models.DTO.Category
{
    public class CreateCategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public List<CreateVideoPostResponseDto> VideoPosts { get; set; } = new List<CreateVideoPostResponseDto>();
    }

}

using VideoPortal.API.Models.DTO.Category;
using VideoPortal.API.Models.DTO.VideoPostComment;

namespace VideoPortal.API.Models.DTO.VideoPost
{
    public class CreateVideoPostResponseDto
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

        public List<CreateCategoryResponseDto> Categories { get; set; } = new List<CreateCategoryResponseDto>();
        public List<CreateCommentResponseDto> Comments { get; set; } = new List<CreateCommentResponseDto>();
    }
}

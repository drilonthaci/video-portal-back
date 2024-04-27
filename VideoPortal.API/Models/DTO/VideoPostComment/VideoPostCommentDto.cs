namespace VideoPortal.API.Models.DTO.VideoPostComment
{
    public class VideoPostCommentDto
    {
        public Guid CommentId { get; set; }
     //   public string UserEmail { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedAt { get; set; }
       // public Guid VideoPostId { get; set; }
        public string VideoPostName { get; set; }
    }
}

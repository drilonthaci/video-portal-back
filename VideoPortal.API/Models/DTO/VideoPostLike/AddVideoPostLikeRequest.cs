namespace VideoPortal.API.Models.DTO.VideoPostLike
{
    public class AddVideoPostLikeRequest
    {
        public Guid VideoPostId { get; set; }
        public Guid UserId { get; set; }
    }

}

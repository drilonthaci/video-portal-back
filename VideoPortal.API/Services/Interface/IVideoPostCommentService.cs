namespace VideoPortal.API.Services.Interface
{
    public interface IVideoPostCommentService
    {
        Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userEmail, string commentText);
    }
}

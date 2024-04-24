namespace VideoPortal.API.Repositories.CommentRepo
{
    public interface IVideoPostCommentRepository
    {
        Task<bool> AddVideoPostCommentAsync(Guid videoPostId, string userEmail, string commentText);
    }
}

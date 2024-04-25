using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Services.VideoPostService
{
    public interface IVideoPostService
    {
        Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id);
        Task<List<VideoPost>> GetAllVideoPostsWithCategoriesAsync();
        Task<List<VideoPost>> SearchAsync(string searchString);

        Task AddAsync(VideoPost videoPost);
        Task UpdateAsync(VideoPost videoPost);
        Task DeleteAsync(Guid id);


    }
}

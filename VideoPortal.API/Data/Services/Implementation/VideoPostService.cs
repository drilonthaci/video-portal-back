using Microsoft.EntityFrameworkCore;
using VideoPortal.API.Data.Repositories.Base;
using VideoPortal.API.Data.Repositories.VideoPostRepo;
using VideoPortal.API.Data.Services.Interface;
using VideoPortal.API.Models.Domain;

namespace VideoPortal.API.Data.Services.Implementation
{
    public class VideoPostService : EntityBaseRepository<VideoPost>, IVideoPostService
    {
        private readonly IVideoPostRepository _videoPostRepository;

        public VideoPostService(IVideoPostRepository videoPostRepository, AppDbContext context)
            : base(context)
        {

            _videoPostRepository = videoPostRepository;
        }

        public async Task<VideoPost> GetVideoPostByIdWithCategoriesAsync(Guid id)
        {
            return await _videoPostRepository.GetVideoPostByIdWithCategoriesAsync(id);
        }
    }
}

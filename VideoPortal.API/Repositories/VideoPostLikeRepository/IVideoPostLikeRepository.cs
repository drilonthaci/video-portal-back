﻿using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.VideoPostLike;

namespace VideoPortal.API.Repositories.VideoPostLikeRepository
{
    public interface IVideoPostLikeRepository
    {
        Task<bool> LikeVideoPostAsync(Guid videoPostId, string userEmail);
        Task<IEnumerable<UserLikeDto>> GetLikesByUserAsync(string userEmail);
        Task<bool> UnlikeVideoPostAsync(Guid videoPostId, string userEmail);
    }
}
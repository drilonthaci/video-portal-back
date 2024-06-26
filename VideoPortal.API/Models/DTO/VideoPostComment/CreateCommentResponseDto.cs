﻿namespace VideoPortal.API.Models.DTO.VideoPostComment
{
    public class CreateCommentResponseDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedAt { get; set; }
    }
}

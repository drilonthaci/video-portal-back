using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPortal.API.Models.DTO.VideoPostComment;
using VideoPortal.API.Services.VideoPostCommentService;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Services.CategoryService;
using VideoPortal.API.Controllers;


namespace VideoPortal_UnitTesting
{
    public class VideoPostCommentsControllerTests
    {
        private Mock<IVideoPostCommentService> _commentServiceMock;
        private VideoPostCommentsController _controller;

        public VideoPostCommentsControllerTests()
        {
            _commentServiceMock = new Mock<IVideoPostCommentService>();
            _controller = new VideoPostCommentsController(_commentServiceMock.Object);
        }

        [Fact]
        public async Task AddVideoPostComment_ReturnsOkResult_WhenCommentIsAddedSuccessfully()
        {
            // Arrange
            var videoPostId = Guid.NewGuid();
            var userEmail = "testuser@example.com";
            var commentText = "This is a test comment.";
            _commentServiceMock.Setup(x => x.AddVideoPostCommentAsync(videoPostId, userEmail, commentText))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.AddVideoPostComment(videoPostId, userEmail, commentText);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddVideoPostComment_ReturnsBadRequest_WhenCommentIsNotAddedSuccessfully()
        {
            // Arrange
            var videoPostId = Guid.NewGuid();
            var userEmail = "testuser@example.com";
            var commentText = "This is a test comment.";
            _commentServiceMock.Setup(x => x.AddVideoPostCommentAsync(videoPostId, userEmail, commentText))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.AddVideoPostComment(videoPostId, userEmail, commentText);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("The comment does not exist.", badRequestResult.Value);
        }

      
    }
}

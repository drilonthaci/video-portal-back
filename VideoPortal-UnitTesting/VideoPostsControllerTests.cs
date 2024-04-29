using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPortal.API.Controllers;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Services.CategoryService;
using VideoPortal.API.Services.VideoPostService;

namespace VideoPortal_UnitTesting
{
    public class VideoPostsControllerTests
    {

        private Mock<ICategoryService> _categoryServiceMock;
        private Mock<IVideoPostService> _videoPostServiceMock;
        private VideoPostsController _controller;

        public VideoPostsControllerTests()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
            _videoPostServiceMock = new Mock<IVideoPostService>();
            _controller = new VideoPostsController(_categoryServiceMock.Object, _videoPostServiceMock.Object);
        }

        [Fact]
        public async Task Search_ReturnsOkResult_WithVideoPostsList()
        {
            // Arrange
            var searchString = "test";
            var videoPosts = new List<VideoPost>
            {
                new VideoPost
                {
                    Id =  Guid.NewGuid(),
                    Title = "Test Video Post 1",
                    ShortDescription = "Test short description 1",
                    ImageUrl = "Test image URL 1",
                    VideoUrl = "Test video URL 1",
                    PublishedDate = System.DateTime.Now,
                    Publisher = "Test publisher 1",
                    Categories = new List<Category>
                    {
                        new Category { Id =  Guid.NewGuid(), Name = "Test Category 1", ShortDescription = "Test short description 1", ImageUrl = "Test image URL 1" }
                    }
                },
                new VideoPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Test Video Post 2",
                    ShortDescription = "Test short description 2",
                    ImageUrl = "Test image URL 2",
                    VideoUrl = "Test video URL 2",
                    PublishedDate = System.DateTime.Now,
                    Publisher = "Test publisher 2",
                    Categories = new List<Category>
                    {
                        new Category { Id = Guid.NewGuid(), Name = "Test Category 2", ShortDescription = "Test short description 2", ImageUrl = "Test image URL 2" }
                    }
                }
            };

            _videoPostServiceMock.Setup(x => x.SearchAsync(searchString)).ReturnsAsync(videoPosts);

            // Act
            var result = await _controller.Search(searchString);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var videoPostsList = Assert.IsAssignableFrom<IEnumerable<VideoPost>>(okResult.Value);
            Assert.Equal(2, videoPostsList.Count());
        }
    }
}

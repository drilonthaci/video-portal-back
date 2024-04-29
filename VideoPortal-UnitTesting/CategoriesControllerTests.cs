using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.Category;
using VideoPortal.API.Services.CategoryService;
using Moq;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Controllers;

namespace VideoPortal_UnitTesting
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task CreateCategory_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var serviceMock = new Mock<ICategoryService>();
            var controller = new CategoriesController(serviceMock.Object);

            var request = new CreateCategoryRequestDto
            {
                Name = "Test Category",
                ShortDescription = "Test short description",
                ImageUrl = "https://example.com/image.jpg"
            };

            // Act
            var result = await controller.CreateCategory(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreateCategoryResponseDto>(result.Value);

            var response = (CreateCategoryResponseDto)result.Value;
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.ShortDescription, response.ShortDescription);
            Assert.Equal(request.ImageUrl, response.ImageUrl);
        }

        [Fact]
        public async Task CreateCategory_InvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var serviceMock = new Mock<ICategoryService>();
            var controller = new CategoriesController(serviceMock.Object);

            var request = new CreateCategoryRequestDto { }; // invalid request

            // Act
            var result = await controller.CreateCategory(request) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SerializableError>(result.Value);
        }

        [Fact]
        public async Task CreateCategory_ServiceThrowsException_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var serviceMock = new Mock<ICategoryService>();
            serviceMock.Setup(s => s.AddAsync(It.IsAny<Category>()))
               .ThrowsAsync(new Exception("Test exception"));

            var controller = new CategoriesController(serviceMock.Object);

            var request = new CreateCategoryRequestDto
            {
                Name = "Test Category",
                ShortDescription = "Test short description",
                ImageUrl = "https://example.com/image.jpg"
            };

            // Act
            var result = await controller.CreateCategory(request) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
    }
}
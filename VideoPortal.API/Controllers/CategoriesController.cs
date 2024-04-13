using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Data;
using VideoPortal.API.Models;
using VideoPortal.API.Models.Dto;
using VideoPortal.API.Models.DTO;
using VideoPortal.API.Repositories.Interface;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreationDto request)
        {


           // Map CreateCategoryRequestDto to Category model
            var category = new Category
            {
                Name = request.Name
            };

            await categoryRepository.CreateAsync(category);

            // Model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(response);

        }
    }
}

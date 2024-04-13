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
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
        {


           // Map CreateCategoryRequestDto to Category model
            var category = new Category
            {
                Name = request.Name
            };

            await categoryRepository.CreateAsync(category);

            // Model to DTO
            var response = new CreateCategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(response);

        }


        // GET: /api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();

            //Domain model to DTO

            var response = new List<CreateCategoryResponseDto>();
            foreach (var category in categories)
            {
                response.Add(new CreateCategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return Ok(response);
        }


        //GET: /categories/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var retrievedCategory = await categoryRepository.GetById(id);

            if (retrievedCategory is null)
            {
                return NotFound();
            }

            var response = new CreateCategoryResponseDto
            {
                Id = retrievedCategory.Id,
                Name = retrievedCategory.Name,
            };

            return Ok(response);
        }



        // PUT: categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequestDto request)
        {
            // DTO to Domain Model
            var category = new Category
            {
                Id = id,
                Name = request.Name
            };

            category = await categoryRepository.UpdateAsync(category);

            if (category == null)
            {
                return NotFound();
            }

            // Domain model to DTO
            var response = new CreateCategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(response);
        }


        // DELETE: categories/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleteAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            // Domain model to DTO
            var response = new CreateCategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(response);
        }

    }
}

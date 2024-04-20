using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Models.Domain;
using VideoPortal.API.Models.DTO.Category;
using VideoPortal.API.Models.DTO.VideoPost;
using VideoPortal.API.Services.Interface;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }


        // POST: api/Categories
        [HttpPost]
        //[Authorize(Roles = "Creator")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map CreateCategoryRequestDto to Category model
            var category = new Category
            {
                Name = request.Name,
                ShortDescription = request.ShortDescription,
                ImageUrl = request.ImageUrl
            };

            await _service.AddAsync(category);

            // Model to DTO
            var response = new CreateCategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                ShortDescription = category.ShortDescription,
                ImageUrl = category.ImageUrl
            };

            return Ok(response);
        }



        // GET: api/Categories
        [HttpGet]
         
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _service.GetAllAsync();

            // Domain model to DTO
            var response = new List<CreateCategoryResponseDto>();
            foreach (var category in categories)
            {
                response.Add(new CreateCategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    ShortDescription = category.ShortDescription,
                    ImageUrl = category.ImageUrl
                });
            }

            return Ok(response);
        }




        // GET: api/categories/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var retrievedCategory = await _service.GetCategoryByIdWithVideoPostsAsync(id);

            if (retrievedCategory == null)
            {
                return NotFound();
            }

            var response = new CreateCategoryResponseDto
            {
                Id = retrievedCategory.Id,
                Name = retrievedCategory.Name,
                ShortDescription = retrievedCategory.ShortDescription,
                ImageUrl = retrievedCategory.ImageUrl,
                VideoPosts = retrievedCategory.VideoPosts.Select(vp => new CreateVideoPostResponseDto
                {
                    Id = vp.Id,
                    Title = vp.Title,
                    ImageUrl = vp.ImageUrl,
                }).ToList()
            };

            return Ok(response);
        }




        // PUT: api/categories/{id}
        [HttpPut("{id:Guid}")]
        //[Authorize(Roles = "Creator")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the category from the database
            var category = await _service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Update category properties with DTO data
            category.Name = request.Name;
            category.ShortDescription = request.ShortDescription;
            category.ImageUrl = request.ImageUrl;

            // Save the updated category
            await _service.UpdateAsync(category);

            // Model to DTO
            var response = new CreateCategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                ShortDescription = category.ShortDescription,
                ImageUrl = category.ImageUrl
            };

            return Ok(response);
        }



        [HttpDelete("{id:Guid}")]
        //[Authorize(Roles = "Creator")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

    }
}

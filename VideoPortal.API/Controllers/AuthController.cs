using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Models.DTO.Register;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;


        public AuthController(UserManager<IdentityUser> userManager)
            
        {
            this.userManager = userManager;
        }

        // POST: /api/auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            // Create IdentityUser object
            var user = new IdentityUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),
            };

            // Create User
            var identityResult = await userManager.CreateAsync(user, request.Password);

            if (identityResult.Succeeded)
            {
                // Add Role to user - Viewer 
                identityResult = await userManager.AddToRoleAsync(user, "Viewer");

                if (identityResult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                if (identityResult.Errors.Any())
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return ValidationProblem(ModelState);
        }

    }
}

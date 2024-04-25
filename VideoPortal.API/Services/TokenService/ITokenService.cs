using Microsoft.AspNetCore.Identity;

namespace VideoPortal.API.Services.TokenService
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}

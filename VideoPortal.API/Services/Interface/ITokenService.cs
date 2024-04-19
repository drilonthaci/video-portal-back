using Microsoft.AspNetCore.Identity;

namespace VideoPortal.API.Services.Interface
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}

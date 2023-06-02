using Microsoft.AspNetCore.Identity;

namespace BlazorProject.Api.Helper
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}

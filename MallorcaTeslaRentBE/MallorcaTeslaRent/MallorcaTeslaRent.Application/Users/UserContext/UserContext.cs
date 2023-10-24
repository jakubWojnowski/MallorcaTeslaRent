using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MallorcaTeslaRent.Application.Users.UserContext;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public CurrentUser? GetCurrentUser()
    {
        var claims = _httpContextAccessor.HttpContext?.User.Claims;
        if (claims == null)
        {
            return null;
        }

        var enumerable = claims as Claim[] ?? claims.ToArray();
        var fullName = enumerable.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        var roles = enumerable.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
        return new CurrentUser(fullName, roles);
    }
}
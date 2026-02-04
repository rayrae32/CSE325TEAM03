using System.Security.Claims;

namespace ServeHub.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int? GetUserIdOrNull(this ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return userIdClaim != null ? int.Parse(userIdClaim) : null;
    }
}

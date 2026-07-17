using System.Security.Claims;
using TheVineHub.API.Features.Users;

namespace TheVineHub.API.Configuration.Authentication;

public interface IJwtService
{
    string GenerateToken(UserAuthDto user, double durationMinutes);
    string GenerateToken(IEnumerable<Claim> claims, double durationMinutes);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

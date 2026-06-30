using System.Security.Claims;
using JMMinistry.Application.Features.User.Dtos;

namespace JMMinistry.Application.Services;

public interface IJwtService
{
    string GenerateToken(UserAuthDto user, double durationMinutes);
    string GenerateToken(IEnumerable<Claim> claims, double durationMinutes);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

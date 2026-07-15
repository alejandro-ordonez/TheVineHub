using TheVineHub.API.Features.Users;
using TheVineHub.API.Configuration.Authentication;
using Mediator;
using Microsoft.Extensions.Configuration;
using SurrealDb.Net;
using System.Security.Authentication;
using System.Security.Claims;

namespace TheVineHub.API.Features.Users.Authenticate
{
    public class RefreshTokenHandler(ISurrealDbSession session, IConfiguration configuration, IJwtService jwtService)
        : ICommandHandler<RefreshTokenCommand, TokenResult>
    {
        public async ValueTask<TokenResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = jwtService.GetPrincipalFromExpiredToken(request.Token);
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new AuthenticationException("Invalid token payload");

            var response = await session.Query($@"
                SELECT * FROM refresh_token
                WHERE token = {request.RefreshToken}
                  AND user = type::record('user', {userId})
                  AND revoked = false
                  AND expires_at > time::now()
                LIMIT 1;",
               cancellationToken);

            var savedToken = response.GetValue<IList<RefreshTokenDto>>(0)?.FirstOrDefault();

            if (savedToken == null)
                throw new AuthenticationException("Invalid or expired refresh token");

            await session.Query($"UPDATE {savedToken.Id} SET revoked = true", cancellationToken);

            var duration = double.Parse(configuration["JwtSettings:DurationInMinutes"] ?? "1440");
            var newJwtToken = jwtService.GenerateToken(principal.Claims, duration);
            var newRefreshToken = jwtService.GenerateRefreshToken();

            await session.Query($@"
                CREATE refresh_token SET
                    user = {userId},
                    token = {newRefreshToken},
                    expires_at = {DateTime.UtcNow.AddDays(7)},
                    revoked = false;", cancellationToken);

            return new TokenResult
            {
                IsAuthenticated = true,
                Token = newJwtToken,
                RefreshToken = newRefreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(duration)
            };
        }
    }
}

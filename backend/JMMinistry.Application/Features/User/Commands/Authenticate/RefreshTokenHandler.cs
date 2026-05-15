using JMMinistry.Common.Dtos.User;
using JMMinistry.Domain.Users;
using Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SurrealDb.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace JMMinistry.Application.Features.User.Commands.RefreshToken
{
    public class RefreshTokenHandler(ISurrealDbSession session, IConfiguration configuration)
        : ICommandHandler<RefreshTokenCommand, TokenResult>
    {
        public async ValueTask<TokenResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = GetPrincipalFromExpiredToken(request.Token);
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

            var savedToken = response.GetValue<IList<Domain.Users.RefreshToken>>(0)?.FirstOrDefault();

            if (savedToken == null)
                throw new AuthenticationException("Invalid or expired refresh token");

            await session.Query($"UPDATE {savedToken.Id} SET revoked = true", cancellationToken);

            var duration = double.Parse(configuration["JwtSettings:DurationInMinutes"] ?? "1440");
            var newJwtToken = GenerateJwtToken(principal.Claims, duration);
            var newRefreshToken = GenerateRefreshToken();

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

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"] ?? throw new ArgumentException("No Key Provided"))),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private string GenerateJwtToken(IEnumerable<Claim> claims, double durationMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"] ?? throw new ArgumentException("No Key Provided")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration["JwtSettings:Issuer"], configuration["JwtSettings:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(durationMinutes), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}

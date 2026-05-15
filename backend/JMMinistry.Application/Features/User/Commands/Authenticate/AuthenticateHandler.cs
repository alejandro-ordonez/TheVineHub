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

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateHandler(ISurrealDbSession session, IConfiguration configuration)
        : ICommandHandler<AuthenticateCommand, TokenResult>
    {
        public async ValueTask<TokenResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var response = await session.Query($@"
                SELECT id, 
                    full_name,
                    ->member_of.out.name AS roles,
                    ->guides.out.disciple_step.name AS guiding_steps
                FROM user
                WHERE id = type::record('user', {request.Document})
                  AND crypto::argon2::compare(password, {request.Password})", cancellationToken);

            var user = response.GetValue<List<AuthUserInfo>>(0)?.FirstOrDefault();

            if (user == null)
                throw new AuthenticationException("Invalid credentials");

            var duration = double.Parse(configuration["JwtSettings:DurationInMinutes"] ?? "1440");
            var jwtToken = GenerateJwtToken(user, duration);
            var refreshToken = GenerateRefreshToken();

            await session.Query($@"
                CREATE refresh_token SET
                    user = {user.Id},
                    token = {refreshToken},
                    expires_at = {DateTime.UtcNow.AddDays(7)},
                    revoked = false;", cancellationToken);

            return new TokenResult
            {
                IsAuthenticated = true,
                Token = jwtToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(duration)
            };
        }

        private string GenerateJwtToken(AuthUserInfo user, double durationMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"] ?? throw new ArgumentException("No Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id!.DeserializeId<string>()),
                new(JwtRegisteredClaimNames.Name, user.Name)
            };

            if (user.Roles != null)
            {
                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim("roles", role));
                }
            }

            if (user.GuidingSteps != null)
            {
                foreach (var step in user.GuidingSteps)
                {
                    claims.Add(new Claim("guiding_steps", step));
                }
            }

            var token = new JwtSecurityToken(
                configuration["JwtSettings:Issuer"], configuration["JwtSettings:Audience"], claims,
                expires: DateTime.UtcNow.AddMinutes(durationMinutes), signingCredentials: credentials);

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

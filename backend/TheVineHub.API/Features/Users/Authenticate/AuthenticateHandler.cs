using TheVineHub.API.Features.Users;
using TheVineHub.API.Configuration.Authentication;
using Mediator;
using Microsoft.Extensions.Configuration;
using SurrealDb.Net;
using System.Security.Authentication;

namespace TheVineHub.API.Features.Users.Authenticate
{
    public class AuthenticateHandler(ISurrealDbSession session, IConfiguration configuration, IJwtService jwtService)
        : ICommandHandler<AuthenticateCommand, TokenResult>
    {
        public async ValueTask<TokenResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var response = await session.Query($@"
                {{
                    LET $user_id = type::record('user', {request.Document});
                    LET $pass = {request.Password};
                    RETURN (SELECT id,
                        full_name,
                        ->member_of.out.name AS roles,
                        ->guides.out.disciple_step.name AS guiding_steps
                    FROM user
                    WHERE id = $user_id
                      AND crypto::argon2::compare(password, $pass))[0];
                }}", cancellationToken);

            var user = response.GetValue<UserAuthDto>(0) ?? throw new AuthenticationException("Invalid credentials");

            var duration = double.Parse(configuration["JwtSettings:DurationInMinutes"] ?? "1440");
            var jwtToken = jwtService.GenerateToken(user, duration);
            var refreshToken = jwtService.GenerateRefreshToken();

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
    }
}

using JMMinistry.Application.Configuration;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Domain;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateHandler(
        UserManager<PersonalInfo> userManager,
        IOptions<JWTSettings> jwtSettings)
        : ICommandHandler<AuthenticateCommand, TokenResult>
    {
        public async ValueTask<TokenResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Document) ??
                throw new AuthenticationException("User not found");

            if (!await userManager.HasPasswordAsync(user))
                throw new AuthenticationException("The user must set a password first");

            if (!await userManager.CheckPasswordAsync(user, request.Password))
                throw new AuthenticationException($"Incorrect credentials for: {request.Document}");

            user.LastAccess = DateTime.UtcNow;
            await userManager.UpdateAsync(user);

            var expiration = DateTime.UtcNow.AddMinutes(jwtSettings.Value.DurationInMinutes);
            var token = await CreateJwtToken(user, expiration);


            return new TokenResult
            {
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(PersonalInfo user, DateTime expiration)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email?? user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            }
                .Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Value.Issuer,
                audience: jwtSettings.Value.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }


}

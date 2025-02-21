using JMMinistry.Application.Configuration;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Domain;
using MediatR;
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
        : IRequestHandler<AuthenticateCommand, TokenResult>
    {
        public async Task<TokenResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Document) ?? 
                throw new AuthenticationException("User not found");

            if (!await userManager.HasPasswordAsync(user))
                throw new AuthenticationException("The user must set a password first");

            if (!await userManager.CheckPasswordAsync(user, request.Password))
                throw new AuthenticationException($"Incorrect credentials for: {request.Document}");

            user.LastAccess = DateTime.UtcNow;
            await userManager.UpdateAsync(user);
            

            var token = await CreateJwtToken(user);


            return new TokenResult
            {
                Document = request.Document,
                IsAuthenticated = true,
                Email = user.Email ?? string.Empty,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Roles = [.. (await userManager.GetRolesAsync(user))]
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(PersonalInfo user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email?? user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("uid", user.Id)
            }
                .Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Value.Issuer,
                audience: jwtSettings.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.Value.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }


}

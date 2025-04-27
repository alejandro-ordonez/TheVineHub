using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using System.Security.Claims;

namespace JMMinistry.Web.Services
{
    public class AuthenticationService(IUserApi userApi, IAuthStateProvider authStateProvider) : IAuthService
    {
        public async Task<bool> LogIn(AuthenticateDto authenticateDto)
        {
            var tokenResult = await userApi.Authenticate(authenticateDto);

            if (tokenResult == null || !tokenResult.Success || tokenResult.Data is null || !(tokenResult?.Data?.IsAuthenticated ?? false))
                return false;

            var authResult = tokenResult.Data;
            await authStateProvider.SetTokenAsync(authResult);

            var claims = authResult?.Token.ParseClaimsFromJwt();
            var claimsIdentity = new ClaimsIdentity(claims, "jwt");
            authStateProvider.NotifyUserAuthenticated(claimsIdentity);

            return true;
        }


        public async Task LogOut()
        {
            await authStateProvider.RemoveToken();
            authStateProvider.NotifyUserLogOut();
        }
    }
}


using Blazored.LocalStorage;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using JMMinistry.Web.Shared;

namespace JMMinistry.Web.Services
{
    public class AuthenticationService(IUserApi userApi, ILocalStorageService localStorage, IAuthStateProvider authStateProvider) : IAuthService
    {
        public async Task<bool> LogIn(AuthenticateDto authenticateDto)
        {
            var tokenResult = await userApi.Authenticate(authenticateDto);

            if (tokenResult == null || !tokenResult.Success || !(tokenResult?.Data?.IsAuthenticated ?? false))
                return false;

            var authResult = tokenResult?.Data;
            await localStorage.SetItemAsync(Constants.JwtToken, authResult);

            authStateProvider.NotifyUserAuthenticated(authResult!.Document);

            return true;
        }


        public async Task LogOut()
        {
            await localStorage.RemoveItemAsync(Constants.JwtToken);
            authStateProvider.NotifyUserLogOut();
        }
    }
}

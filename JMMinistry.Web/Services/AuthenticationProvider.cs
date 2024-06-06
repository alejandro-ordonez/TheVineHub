using Blazored.LocalStorage;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using JMMinistry.Web.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using static JMMinistry.Web.Shared.Constants;

namespace JMMinistry.Web.Services
{
    public class AuthenticationProvider(IUserApi userApi, ILocalStorageService localStorage) : AuthenticationStateProvider, IAuthService
    {
        public async Task<bool> AuthenticateAsync(AuthenticateDto authenticateDto)
        {
            var authResult = await userApi.Authenticate(authenticateDto);

            if (authResult == null || !authResult.Success)
                return false;

            await localStorage.SetItemAsync(JwtToken, authResult.Data!);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return true;
        }

        public async Task LogOut()
        {
            await localStorage.RemoveItemAsync(JwtToken);

            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await localStorage.GetItemAsync<TokenResult>(JwtToken);

            if (savedToken == null)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var claims = savedToken.Token.ParseClaimsFromJwt();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
        }
    }
}

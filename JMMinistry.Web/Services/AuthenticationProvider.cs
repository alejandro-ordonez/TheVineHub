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
    public class AuthenticationProvider(ILocalStorageService localStorage) : AuthenticationStateProvider, IAuthStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await localStorage.GetItemAsync<TokenResult>(JwtToken);

            if (savedToken == null)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var claims = savedToken.Token.ParseClaimsFromJwt();
            var authState =  new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
            return authState;
        }

        public void NotifyUserAuthenticated(string userId)
        {
            var authUser = new ClaimsPrincipal(new ClaimsIdentity(
                    [new Claim(ClaimTypes.Name, userId)], "jwt"
                ));

            var authState = new AuthenticationState(authUser);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public void NotifyUserLogOut()
        {
            var authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
    }
}

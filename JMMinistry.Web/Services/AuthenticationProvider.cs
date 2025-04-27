using Blazored.LocalStorage;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Resources;
using JMMinistry.Web.Api;
using JMMinistry.Web.Extensions;
using JMMinistry.Web.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.JsonWebTokens;
using MudBlazor;
using System.Globalization;
using System.Security.Claims;
using System.Text.Json;
using static JMMinistry.Web.Shared.Constants;

namespace JMMinistry.Web.Services
{
    public class AuthenticationProvider(
        ILocalStorageService localStorage, 
        ISnackbar snackbar, 
        IStringLocalizer<UIStrings> translator
        ) : AuthenticationStateProvider, IAuthStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await GetTokenAsync();

            ClaimsIdentity claimsIdentity;

            if (savedToken == null)
                claimsIdentity = new ClaimsIdentity();

            else
            {
                var claims = savedToken.Token.ParseClaimsFromJwt();
                claimsIdentity = new ClaimsIdentity(claims, "jwt");
            }

                
            var authState =  new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
            return authState;
        }

        public void NotifyUserAuthenticated(ClaimsIdentity claims)
        {
            var authState = new AuthenticationState(new ClaimsPrincipal(claims));
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public void NotifyUserLogOut()
        {
            var authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task<TokenResult?> GetTokenAsync()
        {
            var savedToken = await localStorage.GetItemAsync<TokenResult>(JwtToken);

            if (savedToken == null)
                return null;

            var token = savedToken.Token.ParseClaimsFromJwt();
            var expirationClaim = token.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Exp);

            if(expirationClaim is null)
            {
                await RemoveToken();
                return null;
            }

            var expiration = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(expirationClaim.Value));

            if (expiration.DateTime > DateTime.UtcNow)
                return savedToken;

            else
            {
                snackbar.Add(translator["SessionExpired"], Severity.Error);
                await RemoveToken();
                return null;
            }
        }

        public async Task SetTokenAsync(TokenResult token)
        {
            await localStorage.SetItemAsync(JwtToken, token);
        }

        public async Task RemoveToken()
        {
            await localStorage.RemoveItemAsync(JwtToken);
        }
    }
}

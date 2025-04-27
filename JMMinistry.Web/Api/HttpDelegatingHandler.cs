
using Blazored.LocalStorage;
using Fluxor;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Resources;
using JMMinistry.Web.Services;
using JMMinistry.Web.Shared;
using JMMinistry.Web.Store;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Net;
using System.Net.Http.Headers;

namespace JMMinistry.Web.Api
{
    public class HttpDelegatingHandler(NavigationManager navigationManager,
        IAuthService authenticationService,
        IDispatcher dispatcher,
        IStringLocalizer<UIStrings> localizer,
        ILocalStorageService localStorage) : DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = (await localStorage.GetItemAsync<TokenResult>(Constants.JwtToken, cancellationToken))?.Token;

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Removes the token so next request will redirect to login
                dispatcher.Dispatch(new FailedAction<HttpDelegatingHandler> { ErrorKey = localizer["SessionExpired"] });
                await authenticationService.LogOut();
                navigationManager.NavigateTo("/auth");
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                dispatcher.Dispatch(new FailedAction<HttpDelegatingHandler> { ErrorKey = localizer["ServerError"] });
            }

            return response;

        }
    }
}

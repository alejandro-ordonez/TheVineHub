using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace JMMinistry.Web.Services
{
    public interface IAuthStateProvider
    {
        void NotifyUserAuthenticated(ClaimsIdentity claims);
        void NotifyUserLogOut();

        Task<AuthenticationState> GetAuthenticationStateAsync();
    }
}

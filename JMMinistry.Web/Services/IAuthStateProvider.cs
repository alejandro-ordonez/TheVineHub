using Microsoft.AspNetCore.Components.Authorization;

namespace JMMinistry.Web.Services
{
    public interface IAuthStateProvider
    {
        void NotifyUserAuthenticated(string userId);
        void NotifyUserLogOut();

        Task<AuthenticationState> GetAuthenticationStateAsync();
    }
}

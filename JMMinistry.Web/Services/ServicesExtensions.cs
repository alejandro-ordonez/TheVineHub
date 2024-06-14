using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace JMMinistry.Web.Services
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AuthenticationProvider>();

            services.AddScoped(
                    sp => (IAuthService)sp.GetRequiredService<AuthenticationStateProvider>()
                );

        }
    }
}

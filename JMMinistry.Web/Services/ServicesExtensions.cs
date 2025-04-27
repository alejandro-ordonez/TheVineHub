using Microsoft.AspNetCore.Components.Authorization;

namespace JMMinistry.Web.Services
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AuthenticationProvider>();

            services.AddScoped(
                    sp => (IAuthStateProvider)sp.GetRequiredService<AuthenticationStateProvider>()
                );

            services.AddScoped<IAuthService, AuthenticationService>();
        }
    }
}

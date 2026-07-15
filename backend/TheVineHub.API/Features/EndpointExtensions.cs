using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TheVineHub.API.Features
{
    /// <summary>
    /// Extension methods for scanning and registering all IEndpoint implementations from the assembly.
    /// </summary>
    public static class EndpointExtensions
    {
        /// <summary>
        /// Scans the calling assembly for all non-abstract IEndpoint implementations
        /// and registers them as transient services.
        /// </summary>
        public static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            var endpointTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false } && typeof(IEndpoint).IsAssignableFrom(t));

            foreach (var type in endpointTypes)
                services.AddTransient(typeof(IEndpoint), type);

            return services;
        }

        /// <summary>
        /// Resolves all registered IEndpoint instances and calls MapEndpoint on each.
        /// </summary>
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.ServiceProvider
                .GetRequiredService<IEnumerable<IEndpoint>>();

            foreach (var endpoint in endpoints)
                endpoint.MapEndpoint(app);

            return app;
        }
    }
}

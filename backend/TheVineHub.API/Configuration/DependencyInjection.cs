using FluentValidation;
using TheVineHub.API.Configuration.Authentication;
using TheVineHub.API.Configuration.Pipelines;
using TheVineHub.API.Configuration;
using Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TheVineHub.API.Configuration
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            services.Configure<JWTSettings>(configuration.GetSection(nameof(JWTSettings)));
            services.AddJwtAuthentication(configuration);
            services.AddScoped<IJwtService, JwtService>();

            services.AddMediator(options =>
            {
                options.ServiceLifetime = ServiceLifetime.Scoped;
            });
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        }
    }
}

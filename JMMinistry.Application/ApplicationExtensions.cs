using FluentValidation;
using JMMinistry.Application.Authentication;
using JMMinistry.Application.Configuration;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Pipelines;
using Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JMMinistry.Application
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            services.AddSingleton<AppMapper>();

            services.Configure<JWTSettings>(configuration.GetSection(nameof(JWTSettings)));
            services.AddJwtAuthentication(configuration);

            services.AddMediator(options =>
            {
                options.ServiceLifetime = ServiceLifetime.Scoped;
            });
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly);
        }
    }
}

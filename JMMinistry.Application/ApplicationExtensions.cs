using FluentValidation;
using JMMinistry.Application.Authentication;
using JMMinistry.Application.Configuration;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Pipelines;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JMMinistry.Application
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            services.AddAutoMapper(typeof(MapperProfile));

            services.Configure<JWTSettings>(configuration.GetSection(nameof(JWTSettings)));
            services.AddJwtAuthentication(configuration);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationExtensions).Assembly);
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly);
        }
    }
}

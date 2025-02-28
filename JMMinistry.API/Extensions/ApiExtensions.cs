using JMMinistry.Common;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

namespace JMMinistry.API.Extensions
{
    public static class ApiExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(config =>
            {
                // Bearer token authentication
                OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                };
                config.AddSecurityDefinition("jwt_auth", securityDefinition);

                // Make sure swagger UI requires a Bearer token specified
                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "jwt_auth",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                OpenApiSecurityRequirement securityRequirements = new()
                {
                    {securityScheme, Array.Empty<string>()},
                };
                config.AddSecurityRequirement(securityRequirements);
            });
        }

        public static string? GetDocumentClaim(this HttpContext httpContext)
        {
            var documentClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            var document = documentClaim?.Value;

            return document;
        }

        public static IEnumerable<string> GetRoles(this HttpContext httpContext)
        {
            var roleClaims = httpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.Role);
            var roles = roleClaims.Select(claim => claim.Value);

            return roles;
        }

        public static bool UserHasRole(this HttpContext httpContext, Roles role)
        {
            var roleString = role.ToString();
            return httpContext.User.Claims.Any(
                claim => claim.Type == ClaimTypes.Role && claim.Value == roleString
                );
        }
    }
}

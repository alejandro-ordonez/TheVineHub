using JMMinistry.Web.Extensions;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using JMMinistry.Web.Shared;
using Blazored.LocalStorage;
using JMMinistry.Common.Dtos.User;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace JMMinistry.Web.Api
{
    public static class ApiExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<HttpDelegatingHandler>();

            services
                .AddHttpClient(Constants.ApiClient,  (provider, config) =>
                {
                    var configuration = GetConfiguration();
                    var serverUrl = configuration[Constants.ApiURL] ?? 
                        throw new ArgumentException("Api URL not set");

                    config.BaseAddress = new Uri(serverUrl);
                })
                .AddHttpMessageHandler<HttpDelegatingHandler>();


            services.AddTransient<IUserApi, UserApi>();
            services.AddTransient<ISchoolApi, SchoolApi>();
            services.AddTransient<IMinistryApi, MinistryApi>();
        }

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build(); 
        }



        public static IList<Claim> ParseClaimsFromJwt(this string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = payload.ParseBase64WithoutPadding();
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs == null)
                return [];

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object? roles);

            if (roles == null)
            {
                claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));
                return claims;
            }


            if (roles!.ToString()!.Trim().StartsWith('['))
            {
                var parsedRoles = JsonSerializer.Deserialize<string[]>(roles!.ToString()!);

                foreach (var parsedRole in parsedRoles!)
                {
                    claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, roles!.ToString()!));
            }

            keyValuePairs.Remove(ClaimTypes.Role);

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));
            return claims;
        }
    }
}

using JMMinistry.Web.Extensions;
using JMMinistry.Web.Shared;
using System.Security.Claims;
using System.Text.Json;

namespace JMMinistry.Web.Api
{
    public static class ApiExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<HttpDelegatingHandler>();

            services
                .AddHttpClient(Constants.ApiClient, (provider, config) =>
                {
#if DEBUG
                    var serverUrl = "http://localhost:5217";
#else
                    var configuration = GetConfiguration();
                    var serverUrl = configuration[Constants.ApiURL] ?? 
                        throw new ArgumentException("Api URL not set");
#endif


                    config.BaseAddress = new Uri(serverUrl);
                })
                .AddHttpMessageHandler<HttpDelegatingHandler>();


            services.AddTransient<IUserApi, UserApi>();
            services.AddTransient<ISchoolApi, SchoolApi>();
            services.AddTransient<IMinistryApi, MinistryApi>();
            services.AddTransient<IGainedUsersApi, GainedUserApi>();
            services.AddTransient<IMeetingApi, MeetingApi>();
            services.AddTransient<ILocationApi, LocationApi>();
            services.AddTransient<IDiscipleshipApi, DiscipleshipApi>();
            services.AddTransient<IDiscipleJourneyApi, DiscipleJourneyApi>();
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

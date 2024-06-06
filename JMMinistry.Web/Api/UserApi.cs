using JMMinistry.Common;
using JMMinistry.Common.Dtos.User;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class UserApi : IUserApi
    {
        private const string _userApi = "api/User";
        private readonly HttpClient httpClient;
        private readonly ILogger<UserApi> logger;

        public UserApi(HttpClient httpClient, ILogger<UserApi> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }
        public async Task<Response<TokenResult?>?> Authenticate(AuthenticateDto authenticateDto)
        {
            var result = await httpClient.PostAsJsonAsync($"{_userApi}/auth", authenticateDto);

            var response = await result.Content.ReadFromJsonAsync<Response<TokenResult?>?>();

            if (!response?.Success ?? false)
            {
                logger.LogError("Failed to authenticate, reason: \n {0}", string.Join("\n", response?.Errors ?? []));
            }

            return response;
        }
    }
}

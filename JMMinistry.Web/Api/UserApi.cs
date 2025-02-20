using Blazored.LocalStorage;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Services;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class UserApi(IHttpClientFactory clientFactory, ILogger<UserApi> logger): IUserApi
    {
        private const string _userApi = "api/User";
        private readonly ILogger<UserApi> logger = logger;

        public async Task<Response<TokenResult?>?> Authenticate(AuthenticateDto authenticateDto)
        {
            var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var result = await httpClient.PostAsJsonAsync($"{_userApi}/auth", authenticateDto);

            var response = await result.Content.ReadFromJsonAsync<Response<TokenResult?>?>();

            if (!response?.Success ?? false)
            {
                logger.LogError("Failed to authenticate, reason: \n {Errors}", string.Join("\n", response?.Errors ?? []));
            }

            return response;
        }

        public Task<Response<PagedResponse<UserInfoDto>>> GetUserByCriteria(UserCriteriaSearch userCriteriaSearch = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserInfoDto>?> GetUserInfo()
        {
            var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var result = await httpClient.GetFromJsonAsync<Response<UserInfoDto>>(_userApi);
            return result;
        }
    }
}

using JMMinistry.Common;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Shared;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class UserApi(IHttpClientFactory clientFactory, ILogger<UserApi> logger) : IUserApi
    {
        private const string _userApi = "api/User";
        private readonly ILogger<UserApi> logger = logger;

        public async Task<Response<TokenResult?>?> Authenticate(AuthenticateDto authenticateDto)
        {
            using var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var result = await httpClient.PostAsJsonAsync($"{_userApi}/auth", authenticateDto);

            var response = await result.Content.ReadFromJsonAsync<Response<TokenResult?>?>();

            if (!response?.Success ?? false)
            {
                logger.LogError("Failed to authenticate, reason: \n {Errors}", string.Join("\n", response?.Errors ?? []));
            }

            return response;
        }

        public async Task<Response<PagedResponse<PartialUserInfoDto>>?> GetUserByCriteria(UsersSearchCriteria? userCriteriaSearch)
        {
            using var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var result = await httpClient.PostAsJsonAsync($"{_userApi}/Search", userCriteriaSearch);

            var response = await result.Content.ReadFromJsonAsync<Response<PagedResponse<PartialUserInfoDto>>>();

            if (!response?.Success ?? false)
            {
                logger.LogError("Failed to authenticate, reason: \n {Errors}", string.Join("\n", response?.Errors ?? []));
            }

            return response;
        }

        public async Task<Response<UserInfoDto>?> GetUserInfo(string? document = null)
        {
            using var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var url = _userApi;

            if (!string.IsNullOrEmpty(document))
                url += $"/{document}";

            var result = await httpClient.GetAsync(url);

            return await result.Content.ReadFromJsonAsync<Response<UserInfoDto>>();
        }

        public async Task<Response<object>?> ImportUsers(IBrowserFile file)
        {
            using var content = new MultipartFormDataContent();

            var fileContent = new StreamContent(file.OpenReadStream());

            fileContent.Headers.ContentType =
                new MediaTypeHeaderValue(file.ContentType);

            content.Add(
                content: fileContent,
                name: "\"formFile\"",
                fileName: file.Name);

            using var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var result = await httpClient.PostAsync($"{_userApi}/import", content);

            return await result.Content.ReadFromJsonAsync<Response<object>>();
        }

        public async Task<Response<object>?> CreateUser(CreateUserInfoDto createUserDto)
        {
            using var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var result = await httpClient.PostAsJsonAsync($"{_userApi}/register", createUserDto);

            var response = await result.Content.ReadFromJsonAsync<Response<object>?>();

            if (!response?.Success ?? false)
            {
                logger.LogError("Failed to create user, reason: \n {Errors}", string.Join("\n", response?.Errors ?? []));
            }

            return response;
        }

        public async Task<Response<DocumentCheckResultDto>?> CheckDocumentExists(string document)
        {
            using var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var result = await httpClient.GetAsync($"{_userApi}/Check/{document}");

            return await result.Content.ReadFromJsonAsync<Response<DocumentCheckResultDto>>();
        }
    }
}

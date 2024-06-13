using Blazored.LocalStorage;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Shared;

namespace JMMinistry.Web.Api
{
    public abstract class BaseApi: IDisposable
    {
        protected readonly HttpClient _httpClient;

        public BaseApi(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;

            var tokenTask = localStorage.GetItemAsync<TokenResult>(Constants.JwtToken);
            
            if(tokenTask.IsCompleted)
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenTask.Result?.Token);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

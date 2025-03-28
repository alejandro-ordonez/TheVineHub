using JMMinistry.Common;
using JMMinistry.Common.Dtos.Gained;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class GainedUserApi(IHttpClientFactory clientFactory) : IGainedUsersApi
    {
        private const string _gainedUsersApi = "api/Gained";

        public async Task<Response<IList<GainedUser>>?> GetGainedUsers()
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetFromJsonAsync<Response<IList<GainedUser>>>(_gainedUsersApi);
            return response;
        }

        public async Task<Response<GainedUser>?> RegisterGainedPerson(CreateGainedUser createGained)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync(_gainedUsersApi, createGained);
            return await response.Content.ReadFromJsonAsync<Response<GainedUser>>();
        }
    }
}

using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Shared;
using Microsoft.AspNetCore.WebUtilities;
using System.Buffers.Text;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class MinistryApi(IHttpClientFactory clientFactory) : IMinistryApi
    {
        private const string _ministryApi = "api/Ministry";

        public async Task<Response<CellDto>?> CreateCell(CreateCellDto cell)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync(_ministryApi, cell);
            return await response.Content.ReadFromJsonAsync<Response<CellDto>>();
        }

        public async Task<Response<IList<CellDto>>?> GetAsync()
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetFromJsonAsync<Response<IList<CellDto>>?>(_ministryApi);
            return response;
        }

        public async Task<Response<CellDto>?> GetAsync(int cellId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetFromJsonAsync<Response<CellDto>?>($"{_ministryApi}/{cellId}");
            return response;
        }

        public async Task<Response<IList<PartialUserInfoDto>>?> AddDisciples(AddDisciplesDto addDisciples)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_ministryApi}/disciples/{addDisciples.CellId}", addDisciples);
            return await response.Content.ReadFromJsonAsync<Response<IList<PartialUserInfoDto>>>();
        }

        public async Task<Response<IList<PartialUserInfoDto>>?> RemoveDiscipleFromCell(int cellId, string document)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.DeleteAsync($"{_ministryApi}/disciples/{cellId}/{document}");
            return await response.Content.ReadFromJsonAsync<Response<IList<PartialUserInfoDto>>>();
        }

        public async Task<Response<IList<PartialUserInfoDto>>?> GetDisciples(int cellId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);

            var url = $"{_ministryApi}/disciples/{cellId}";

            var response = await client.GetFromJsonAsync<Response<IList<PartialUserInfoDto>>?>(url);
            return response;
        }

       
    }
}

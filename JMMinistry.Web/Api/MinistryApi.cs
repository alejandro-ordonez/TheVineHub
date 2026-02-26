using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class MinistryApi(IHttpClientFactory clientFactory) : IMinistryApi
    {
        private const string _ministryApi = "api/Ministry";

        public async Task<Response<CellDto>?> CreateCell(CellDto cell)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync(_ministryApi, cell);
            return await response.Content.ReadFromJsonAsync<Response<CellDto>>();
        }

        public async Task<Response<IList<CellDto>>?> GetAsync()
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync(_ministryApi);

            return await response.Content.ReadFromJsonAsync<Response<IList<CellDto>>>();
        }

        public async Task<Response<CellDto>?> GetAsync(int cellId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_ministryApi}/{cellId}");
            return await response.Content.ReadFromJsonAsync<Response<CellDto>?>();
        }

        public async Task<Response<object>?> UpdateCellAsync(CellDto cell)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PutAsJsonAsync($"{_ministryApi}", cell);
            return await response.Content.ReadFromJsonAsync<Response<object>?>();
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

            var response = await client.GetAsync(url);
            return await response.Content.ReadFromJsonAsync<Response<IList<PartialUserInfoDto>>?>();
        }

        public async Task<Response<object>?> RecordCellAttendance(int cellId, AddCellAttendanceDto cellAttendance)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);

            var url = $"{_ministryApi}/attendances/{cellId}";
            var response = await client.PostAsJsonAsync(url, cellAttendance);
            return await response.Content.ReadFromJsonAsync<Response<object>?>();
        }

        public async Task<Response<object>?> UpdateCellAttendance(int cellId, int attendanceId, UpdateCellAttendanceDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);

            var url = $"{_ministryApi}/attendances/{cellId}/{attendanceId}";
            var response = await client.PutAsJsonAsync(url, dto);
            return await response.Content.ReadFromJsonAsync<Response<object>?>();
        }

        public async Task<Response<IList<CellAttendanceDto>>?> GetCellAttendances(int cellId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);

            var url = $"{_ministryApi}/attendances/{cellId}";

            var response = await client.GetAsync(url);
            return await response.Content.ReadFromJsonAsync<Response<IList<CellAttendanceDto>>?>();
        }
    }
}

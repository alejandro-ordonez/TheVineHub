using JMMinistry.Common;
using JMMinistry.Common.Dtos.School;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class SchoolApi(IHttpClientFactory clientFactory) : ISchoolApi
    {
        private const string _schoolApi = "api/School";

        public async Task<Response<SchoolDto>?> CreateSchool(SchoolDto schoolDto, CancellationToken cancellationToken = default)
        {
            var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var response = await httpClient.PostAsJsonAsync(_schoolApi, schoolDto, cancellationToken);

            if (response == null || !response.IsSuccessStatusCode)
                return null;

            var dto = await response.Content.ReadFromJsonAsync<Response<SchoolDto>?>();
            return dto;
        }

        public async Task<Response<SchoolDto>?> UpdateSchool(SchoolDto schoolDto, CancellationToken cancellationToken = default)
        {
            var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var response = await httpClient.PutAsJsonAsync(_schoolApi, schoolDto, cancellationToken);

            if (response == null || !response.IsSuccessStatusCode)
                return null;

            var dto = await response.Content.ReadFromJsonAsync<Response<SchoolDto>?>(cancellationToken);
            return dto;
        }

        public async Task<Response<SchoolWithClassesDto>?> GetSchool(int schoolId, CancellationToken cancellationToken = default)
        {
            var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var response = await httpClient.GetAsync($"{_schoolApi}/{schoolId}", cancellationToken);
            return await response.Content.ReadFromJsonAsync<Response<SchoolWithClassesDto>?>(cancellationToken);
        }

        public async Task<Response<IEnumerable<SchoolDto>>?> GetSchools(CancellationToken cancellationToken = default)
        {
            var httpClient = clientFactory.CreateClient(Constants.ApiClient);
            var response = await httpClient.GetAsync(_schoolApi, cancellationToken);
            return await response.Content.ReadFromJsonAsync<Response<IEnumerable<SchoolDto>>>(cancellationToken);
        }
    }
}

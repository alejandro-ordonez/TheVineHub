
using Blazored.LocalStorage;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.School;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class SchoolApi(HttpClient httpClient): ISchoolApi
    {
        private const string _schoolApi = "api/School";

        public async Task<Response<SchoolDto>?> CreateSchool(SchoolDto schoolDto, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.PostAsJsonAsync(_schoolApi, schoolDto, cancellationToken);

            if(response == null || !response.IsSuccessStatusCode)
                return null;

            var dto = await response.Content.ReadFromJsonAsync<Response<SchoolDto>?>();
            return dto;
        }

        public async Task<Response<SchoolDto>?> UpdateSchool(SchoolDto schoolDto, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.PutAsJsonAsync(_schoolApi, schoolDto, cancellationToken);

            if (response == null || !response.IsSuccessStatusCode)
                return null;

            var dto = await response.Content.ReadFromJsonAsync<Response<SchoolDto>?>();
            return dto;
        }

        public async Task<Response<SchoolWithClassesDto>?> GetSchool(int schoolId, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetFromJsonAsync<Response<SchoolWithClassesDto>?>($"{_schoolApi}/{schoolId}", cancellationToken);
            return response;
        }

        public async Task<Response<IEnumerable<SchoolDto>>?> GetSchools(CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetFromJsonAsync<Response<IEnumerable<SchoolDto>>>(_schoolApi, cancellationToken);
            return response;
        }
    }
}


using JMMinistry.Common;
using JMMinistry.Common.Dtos.School;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class SchoolApi(HttpClient httpClient) : ISchoolApi
    {
        private const string _schoolApi = "api/School";

        public Task CreateSchool(SchoolDto schoolDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SchoolWithClassesDto>?> GetSchool(int schoolId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<SchoolDto>>?> GetSchools(CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetFromJsonAsync<Response<IEnumerable<SchoolDto>>>(_schoolApi, cancellationToken);
            return response;
        }
    }
}

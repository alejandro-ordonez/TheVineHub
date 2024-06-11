
using JMMinistry.Common;
using JMMinistry.Common.Dtos.School;

namespace JMMinistry.Web.Api
{
    public class SchoolApi(HttpClient httpClient) : ISchoolApi
    {
        private const string _schoolApi = "api/School";

        public Task CreateSchool(SchoolDto schoolDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SchoolWithClassesDto>> GetSchool(int schoolId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ICollection<SchoolDto>>> GetSchools()
        {
            throw new NotImplementedException();
        }
    }
}

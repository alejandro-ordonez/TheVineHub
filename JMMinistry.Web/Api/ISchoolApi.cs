using JMMinistry.Common;
using JMMinistry.Common.Dtos.School;

namespace JMMinistry.Web.Api
{
    public interface ISchoolApi
    {
        Task CreateSchool(SchoolDto schoolDto);

        Task<Response<SchoolWithClassesDto>> GetSchool(int schoolId);

        Task<Response<ICollection<SchoolDto>>> GetSchools();
    }
}

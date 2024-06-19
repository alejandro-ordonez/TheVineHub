using JMMinistry.Common;
using JMMinistry.Common.Dtos.School;

namespace JMMinistry.Web.Api
{
    public interface ISchoolApi
    {
        Task<Response<SchoolDto>?> CreateSchool(SchoolDto schoolDto, CancellationToken cancellationToken = default);
        Task<Response<SchoolDto>?> UpdateSchool(SchoolDto schoolDto, CancellationToken cancellationToken = default);

        Task<Response<SchoolWithClassesDto>?> GetSchool(int schoolId, CancellationToken cancellationToken = default);

        Task<Response<IEnumerable<SchoolDto>>?> GetSchools(CancellationToken cancellationToken = default);
    }
}

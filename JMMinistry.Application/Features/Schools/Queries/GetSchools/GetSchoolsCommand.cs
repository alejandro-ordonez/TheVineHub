using JMMinistry.Common.Dtos.School;
using Mediator;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchools
{
    public class GetSchoolsCommand : IQuery<IEnumerable<SchoolDto>>
    {
    }
}

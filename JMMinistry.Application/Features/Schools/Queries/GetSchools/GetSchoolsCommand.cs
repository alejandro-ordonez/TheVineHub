using JMMinistry.Common.Dtos.School;
using MediatR;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchools
{
    public class GetSchoolsCommand : IRequest<IEnumerable<SchoolDto>>
    {
    }
}

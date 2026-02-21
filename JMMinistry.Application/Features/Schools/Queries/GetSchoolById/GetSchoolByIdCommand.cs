using JMMinistry.Common.Dtos.School;
using Mediator;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchoolById
{
    public class GetSchoolByIdCommand : IQuery<SchoolWithClassesDto>
    {
        public int SchoolId { get; set; }
    }
}

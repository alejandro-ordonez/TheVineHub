using JMMinistry.Common.Dtos.School;
using MediatR;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchoolById
{
    public class GetSchoolByIdCommand : IRequest<SchoolWithClassesDto>
    {
        public int SchoolId { get; set; }
    }
}

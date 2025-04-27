using JMMinistry.Common.Dtos.School;
using MediatR;

namespace JMMinistry.Application.Features.Schools.Commands.CreateSchool
{
    public class UpsertSchoolCommand : SchoolDto, IRequest<SchoolDto>
    {
    }
}

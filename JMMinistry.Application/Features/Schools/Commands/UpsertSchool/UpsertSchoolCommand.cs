using JMMinistry.Common.Dtos.School;
using Mediator;

namespace JMMinistry.Application.Features.Schools.Commands.CreateSchool
{
    public class UpsertSchoolCommand : SchoolDto, ICommand<SchoolDto>
    {
    }
}

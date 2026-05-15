using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleAttendance
{
    public class GetCycleAttendanceQuery : IQuery<IList<CycleAttendanceDto>>
    {
        public required string CycleId { get; set; }
    }

    public class GetCycleAttendanceValidator : AbstractValidator<GetCycleAttendanceQuery>
    {
        public GetCycleAttendanceValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}

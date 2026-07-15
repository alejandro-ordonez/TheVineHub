using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Sessions;
using TheVineHub.API.Features.DiscipleJourney.Staff;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Attendance;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Attendance
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

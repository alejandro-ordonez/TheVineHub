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

namespace TheVineHub.API.Features.DiscipleJourney.Cycles
{
    public class GetCycleDetailsQuery : IQuery<IList<CycleEnrollmentDto>>
    {
        public required string CycleId { get; set; }
    }

    public class GetCycleDetailsValidator : AbstractValidator<GetCycleDetailsQuery>
    {
        public GetCycleDetailsValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}

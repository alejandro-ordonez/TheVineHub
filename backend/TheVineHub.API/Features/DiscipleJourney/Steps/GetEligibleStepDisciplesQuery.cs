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

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class GetEligibleStepDisciplesQuery : IQuery<IList<StepDisciplesByCellDto>>
    {
        public required string RequestorId { get; set; }
        public required string StepId { get; set; }
    }

    public class GetEligibleStepDisciplesValidator : AbstractValidator<GetEligibleStepDisciplesQuery>
    {
        public GetEligibleStepDisciplesValidator()
        {
            RuleFor(x => x.RequestorId).NotEmpty();
            RuleFor(x => x.StepId).NotEmpty();
        }
    }
}

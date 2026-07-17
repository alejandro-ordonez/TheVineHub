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
    public class CreateStepCycleCommand : ICommand<StepCycleDto>
    {
        public required string StepId { get; set; }
        public required string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public DateOnly? EnrollmentDeadline { get; set; }
    }

    public class CreateStepCycleValidator : AbstractValidator<CreateStepCycleCommand>
    {
        public CreateStepCycleValidator()
        {
            RuleFor(x => x.StepId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate);
            RuleFor(x => x.MinAttendanceRequired).GreaterThan(0);
        }
    }
}

using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle
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

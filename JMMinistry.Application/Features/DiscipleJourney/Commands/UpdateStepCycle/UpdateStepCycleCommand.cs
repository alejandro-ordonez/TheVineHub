using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle
{
    public class UpdateStepCycleCommand : ICommand<StepCycleDto>
    {
        public required int StepId { get; set; }
        public required int CycleId { get; set; }
        public required string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public bool IsOpen { get; set; }
        public DateOnly? EnrollmentDeadline { get; set; }
    }

    public class UpdateStepCycleValidator : AbstractValidator<UpdateStepCycleCommand>
    {
        public UpdateStepCycleValidator()
        {
            RuleFor(x => x.CycleId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate);
            RuleFor(x => x.MinAttendanceRequired).GreaterThan(0);
        }
    }
}

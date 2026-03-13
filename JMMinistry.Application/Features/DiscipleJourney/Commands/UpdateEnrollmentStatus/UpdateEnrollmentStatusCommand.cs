using FluentValidation;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus
{
    public class UpdateEnrollmentStatusCommand : ICommand
    {
        public required int CycleId { get; set; }
        public required int EnrollmentId { get; set; }
        public StepStatus Status { get; set; }
    }

    public class UpdateEnrollmentStatusValidator : AbstractValidator<UpdateEnrollmentStatusCommand>
    {
        public UpdateEnrollmentStatusValidator()
        {
            RuleFor(x => x.EnrollmentId).GreaterThan(0);
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}

using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus
{
    public class UpdateEnrollmentStatusCommand : ICommand
    {
        public required string CycleId { get; set; }
        public required string EnrollmentId { get; set; }
        public StepStatus Status { get; set; }
    }

    public class UpdateEnrollmentStatusValidator : AbstractValidator<UpdateEnrollmentStatusCommand>
    {
        public UpdateEnrollmentStatusValidator()
        {
            RuleFor(x => x.EnrollmentId).NotEmpty();
            RuleFor(x => x.CycleId).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}

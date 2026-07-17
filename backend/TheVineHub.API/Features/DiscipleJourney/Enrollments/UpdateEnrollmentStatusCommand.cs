using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using TheVineHub.API.Features.DiscipleJourney;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
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

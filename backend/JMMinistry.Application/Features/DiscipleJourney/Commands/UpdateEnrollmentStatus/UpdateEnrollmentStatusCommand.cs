using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus
{
    public class UpdateEnrollmentStatusCommand : ICommand
    {
        [Column("cycle_id")]
        public required string CycleId { get; set; }
        [Column("enrollment_id")]
        public required string EnrollmentId { get; set; }
        [Column("status")]
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

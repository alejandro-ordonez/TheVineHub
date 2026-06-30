using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide
{
    public class AssignGuideCommand : ICommand
    {
        [Column("cycle_id")]
        public required string CycleId { get; set; }
        [Column("cycle_staff_id")]
        public required string CycleStaffId { get; set; }
        [Column("enrollment_ids")]
        public IList<string> EnrollmentIds { get; set; } = [];
    }

    public class AssignGuideValidator : AbstractValidator<AssignGuideCommand>
    {
        public AssignGuideValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
            RuleFor(x => x.CycleStaffId).NotEmpty();
            RuleFor(x => x.EnrollmentIds).NotEmpty();
        }
    }
}

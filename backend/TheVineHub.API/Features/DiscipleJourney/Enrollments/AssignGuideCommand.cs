using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
{
    public class AssignGuideCommand : ICommand
    {
        public required string CycleId { get; set; }
        public required string CycleStaffId { get; set; }
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

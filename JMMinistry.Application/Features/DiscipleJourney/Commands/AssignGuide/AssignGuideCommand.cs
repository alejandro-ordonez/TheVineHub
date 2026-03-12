using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide
{
    public class AssignGuideCommand : ICommand
    {
        public required int CycleId { get; set; }
        public required int CycleStaffId { get; set; }
        public IList<int> EnrollmentIds { get; set; } = [];
    }

    public class AssignGuideValidator : AbstractValidator<AssignGuideCommand>
    {
        public AssignGuideValidator()
        {
            RuleFor(x => x.CycleId).GreaterThan(0);
            RuleFor(x => x.CycleStaffId).GreaterThan(0);
            RuleFor(x => x.EnrollmentIds).NotEmpty();
        }
    }
}

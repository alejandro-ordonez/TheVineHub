using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RemoveCycleStaff
{
    public class RemoveCycleStaffCommand : ICommand
    {
        public required int CycleId { get; set; }
        public required int StaffId { get; set; }
    }

    public class RemoveCycleStaffValidator : AbstractValidator<RemoveCycleStaffCommand>
    {
        public RemoveCycleStaffValidator()
        {
            RuleFor(x => x.StaffId).GreaterThan(0);
        }
    }
}

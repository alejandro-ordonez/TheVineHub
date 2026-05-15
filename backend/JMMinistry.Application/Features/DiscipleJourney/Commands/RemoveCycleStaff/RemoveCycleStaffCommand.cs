using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RemoveCycleStaff
{
    public class RemoveCycleStaffCommand : ICommand
    {
        public required string CycleId { get; set; }
        public required string StaffId { get; set; }
    }

    public class RemoveCycleStaffValidator : AbstractValidator<RemoveCycleStaffCommand>
    {
        public RemoveCycleStaffValidator()
        {
            RuleFor(x => x.StaffId).NotEmpty();
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}

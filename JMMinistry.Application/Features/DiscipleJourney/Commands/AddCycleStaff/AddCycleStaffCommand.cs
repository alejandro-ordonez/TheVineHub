using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff
{
    public class AddCycleStaffCommand : ICommand<CycleStaffDto>
    {
        public required int CycleId { get; set; }
        public required string PersonId { get; set; }
        public CycleStaffRole Role { get; set; }
    }

    public class AddCycleStaffValidator : AbstractValidator<AddCycleStaffCommand>
    {
        public AddCycleStaffValidator()
        {
            RuleFor(x => x.CycleId).GreaterThan(0);
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.Role).IsInEnum();
        }
    }
}

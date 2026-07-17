using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Staff
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

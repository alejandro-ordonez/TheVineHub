using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Sessions;
using TheVineHub.API.Features.DiscipleJourney.Staff;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Attendance;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Staff
{
    public class AddCycleStaffCommand : ICommand<CycleStaffDto>
    {
        public required string CycleId { get; set; }
        public required string PersonId { get; set; }
        public CycleStaffRole Role { get; set; }
    }

    public class AddCycleStaffValidator : AbstractValidator<AddCycleStaffCommand>
    {
        public AddCycleStaffValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.Role).IsInEnum();
        }
    }
}

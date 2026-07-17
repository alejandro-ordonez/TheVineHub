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
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Sessions
{
    public class CreateCycleSessionCommand : ICommand<CycleSessionDto>
    {
        public required string CycleId { get; set; }
        public DateOnly Date { get; set; }
        public string? Topic { get; set; }
    }

    public class CreateCycleSessionValidator : AbstractValidator<CreateCycleSessionCommand>
    {
        public CreateCycleSessionValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}

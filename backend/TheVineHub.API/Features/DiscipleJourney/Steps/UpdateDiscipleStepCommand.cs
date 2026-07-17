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

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class UpdateDiscipleStepCommand : ICommand<DiscipleStepDto>
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required StepCategory StepCategory { get; set; }
        public bool RequiresCycle { get; set; }
        public bool RequiresAdminApproval { get; set; }
        public IList<string> RequirementIds { get; set; } = [];
        public string? ParentStepId { get; set; }
    }

    public class UpdateDiscipleStepValidator : AbstractValidator<UpdateDiscipleStepCommand>
    {
        public UpdateDiscipleStepValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.StepCategory).IsInEnum();
        }
    }
}

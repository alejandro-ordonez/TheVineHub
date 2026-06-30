using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.DiscipleJourney.Dtos;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep
{
    public class UpdateDiscipleStepCommand : ICommand<DiscipleStepDto>
    {
        [Column("id")]
        public required string Id { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("description")]
        public required string Description { get; set; }
        [Column("step_category")]
        public required StepCategory StepCategory { get; set; }
        [Column("requires_cycle")]
        public bool RequiresCycle { get; set; }
        [Column("requires_admin_approval")]
        public bool RequiresAdminApproval { get; set; }
        [Column("requirement_ids")]
        public IList<string> RequirementIds { get; set; } = [];
        [Column("parent_step_id")]
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

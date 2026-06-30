using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep
{
    public class CreateDiscipleStepDto
    {
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
}

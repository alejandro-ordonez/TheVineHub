using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using SurrealDb.Net.Models;

namespace JMMinistry.Application.Features.DiscipleJourney.Dtos
{
    public class DiscipleStepDto
    {
        [Column("id")]
        public RecordId? Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("description")]
        public string Description { get; set; } = string.Empty;
        [Column("parent_id")]
        public string? ParentId { get; set; }
        [Column("step_category")]
        public StepCategory StepCategory { get; set; }
        [Column("requires_cycle")]
        public bool RequiresCycle { get; set; }
        [Column("requires_admin_approval")]
        public bool RequiresAdminApproval { get; set; }
        [Column("requirement_ids")]
        public IList<string> RequirementIds { get; set; } = [];
        /*
        [Column("sub_steps")]
        public IList<DiscipleStepDto> SubSteps { get; set; } = [];
        */
    }
}

using SurrealDb.Net.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JMMinistry.Domain.DiscipleJourney
{
    public class BaseDiscipleStep : Record
    {
        [Column(name: "name")]
        public required string Name { get; set; }

        [Column(name: "description")]
        public required string Description { get; set; }

        [Column(name: "category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required StepCategory StepCategory { get; set; }

        [Column(name: "requires_cycle")]
        public bool RequiresCycle { get; set; }

        [Column(name: "requires_admin_approval")]
        public bool RequiresAdminApproval { get; set; }

        

        [Column(name: "requirement_ids")]
        public List<RecordId> RequirementIds { get; set; } = [];

        [Column(name: "parent_step")]
        public RecordId? ParentStepId { get; set; }
    }

    public class DiscipleStep : BaseDiscipleStep
    {
        [Column(name: "sub_steps")]
        public IList<BaseDiscipleStep>? SubSteps { get; set; } = [];
    }
}

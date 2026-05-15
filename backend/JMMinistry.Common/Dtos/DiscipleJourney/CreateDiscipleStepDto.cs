using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CreateDiscipleStepDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required StepCategory StepCategory { get; set; }
        public bool RequiresCycle { get; set; }
        public bool RequiresAdminApproval { get; set; }
        public IList<string> RequirementIds { get; set; } = [];
        public string? ParentStepId { get; set; }
    }
}

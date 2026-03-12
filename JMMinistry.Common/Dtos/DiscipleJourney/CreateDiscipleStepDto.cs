using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CreateDiscipleStepDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public StepCategory StepCategory { get; set; }
        public bool RequiresCycle { get; set; }
        public IList<int> RequirementIds { get; set; } = [];
        public int? ParentStepId { get; set; }
    }
}

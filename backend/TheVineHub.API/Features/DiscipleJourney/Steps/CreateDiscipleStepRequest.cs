using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.DiscipleJourney;

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class CreateDiscipleStepRequest
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

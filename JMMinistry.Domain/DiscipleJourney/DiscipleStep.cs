using System;
using System.Collections.Generic;
using System.Text;

namespace JMMinistry.Domain.DiscipleJourney
{
    public class DiscipleStep
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public required StepCategory StepCategory { get; set; }

        public int? ParentStepId { get; set; }
        public DiscipleStep? ParentStep { get; set; }
        public IList<DiscipleStep> SubSteps { get; set; } = [];

        public IList<DiscipleStep> DiscipleStepRequirements { get; set; } = [];
    }
}

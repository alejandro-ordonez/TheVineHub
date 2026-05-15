using System;
using System.Collections.Generic;
using System.Text;

namespace JMMinistry.Domain.DiscipleJourney
{
    public class StepCompletion
    {
        public int Id { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateOnly LastUpdated { get; set; }
        public  StepStatus StepStatus { get; set; }

        // Navigation properties

        public int DiscipleStepId { get; set; }
        public DiscipleStep? DiscipleStep { get; set; }


        public string DiscipleId { get; set; } = null!;
        public PersonalInfo? Disciple { get; set; }

        /// <summary>
        /// Leader Id with whom the disciple achieved this step.
        /// </summary>
        public string LeaderId { get; set; } = null!;
        public PersonalInfo? Leader { get; set; }

        public int? StepCycleId { get; set; }
        public StepCycle? StepCycle { get; set; }
    }
}

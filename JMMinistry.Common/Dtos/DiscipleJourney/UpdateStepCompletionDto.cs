using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class UpdateStepCompletionDto
    {
        public StepStatus Status { get; set; }
        public DateOnly? CompletionDate { get; set; }
    }
}

using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class UpdateStepCycleDto : CreateStepCycleDto
    {
        public bool IsOpen { get; set; }
    }
}

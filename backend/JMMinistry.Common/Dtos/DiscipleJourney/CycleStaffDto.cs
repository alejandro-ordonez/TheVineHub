using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CycleStaffDto
    {
        public string Id { get; set; } = string.Empty;
        public string StepCycleId { get; set; } = string.Empty;
        public string PersonId { get; set; } = string.Empty;
        public string PersonName { get; set; } = string.Empty;
        public CycleStaffRole Role { get; set; }
    }
}

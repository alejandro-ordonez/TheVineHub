using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CycleStaffDto
    {
        public int Id { get; set; }
        public int StepCycleId { get; set; }
        public string PersonId { get; set; } = string.Empty;
        public string PersonName { get; set; } = string.Empty;
        public CycleStaffRole Role { get; set; }
    }
}

using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CreateCycleStaffDto
    {
        public string PersonId { get; set; } = string.Empty;
        public CycleStaffRole Role { get; set; }
    }
}

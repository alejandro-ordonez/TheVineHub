using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CreateCycleStaffDto
    {
        public required string PersonId { get; set; }
        public CycleStaffRole Role { get; set; }
    }
}

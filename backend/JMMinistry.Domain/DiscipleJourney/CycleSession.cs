namespace JMMinistry.Domain.DiscipleJourney
{
    public class CycleSession
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Topic { get; set; }

        // Navigation properties

        public int StepCycleId { get; set; }
        public StepCycle? StepCycle { get; set; }

        public IList<CycleAttendance> Attendances { get; set; } = [];
    }
}

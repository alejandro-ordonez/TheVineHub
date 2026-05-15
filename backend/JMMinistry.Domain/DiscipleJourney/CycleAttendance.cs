namespace JMMinistry.Domain.DiscipleJourney
{
    public class CycleAttendance
    {
        public int Id { get; set; }

        // Navigation properties

        public int CycleSessionId { get; set; }
        public CycleSession? CycleSession { get; set; }

        public string DiscipleId { get; set; } = null!;
        public PersonalInfo? Disciple { get; set; }
    }
}

namespace JMMinistry.Domain.DiscipleJourney
{
    public class CycleStaff
    {
        public int Id { get; set; }
        public CycleStaffRole Role { get; set; }

        // Navigation properties

        public int StepCycleId { get; set; }
        public StepCycle? StepCycle { get; set; }

        public string PersonId { get; set; } = null!;
        public PersonalInfo? Person { get; set; }

        public IList<CycleEnrollment> Enrollments { get; set; } = [];
    }
}

namespace JMMinistry.Domain.DiscipleJourney
{
    public class CycleEnrollment
    {
        public int Id { get; set; }
        public EnrollmentStatus Status { get; set; }
        public DateOnly EnrolledAt { get; set; }

        // Navigation properties

        public int StepCycleId { get; set; }
        public StepCycle? StepCycle { get; set; }

        public string DiscipleId { get; set; } = null!;
        public PersonalInfo? Disciple { get; set; }

        public int? CycleStaffId { get; set; }
        public CycleStaff? CycleStaff { get; set; }
    }
}

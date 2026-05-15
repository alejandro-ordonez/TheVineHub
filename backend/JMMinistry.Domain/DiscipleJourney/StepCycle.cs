namespace JMMinistry.Domain.DiscipleJourney
{
    public class StepCycle
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public bool IsOpen { get; set; }
        public DateOnly? EnrollmentDeadline { get; set; }

        // Navigation properties

        public int DiscipleStepId { get; set; }
        public DiscipleStep? DiscipleStep { get; set; }

        public IList<CycleSession> Sessions { get; set; } = [];
        public IList<CycleEnrollment> Enrollments { get; set; } = [];
        public IList<CycleStaff> Staff { get; set; } = [];
    }
}

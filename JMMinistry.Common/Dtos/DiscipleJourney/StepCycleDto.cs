namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class StepCycleDto
    {
        public int Id { get; set; }
        public int DiscipleStepId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public bool IsOpen { get; set; }
        public DateOnly? EnrollmentDeadline { get; set; }
        public int SessionCount { get; set; }
        public int EnrolledCount { get; set; }
    }
}

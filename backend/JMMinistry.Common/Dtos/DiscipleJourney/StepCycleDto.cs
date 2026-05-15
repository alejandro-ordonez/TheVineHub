namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class StepCycleDto
    {
        public string Id { get; set; } = string.Empty;
        public string DiscipleStepId { get; set; } = string.Empty;
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

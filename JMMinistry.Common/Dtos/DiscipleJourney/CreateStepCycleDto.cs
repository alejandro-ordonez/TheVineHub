namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CreateStepCycleDto
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public DateOnly? EnrollmentDeadline { get; set; }
    }
}

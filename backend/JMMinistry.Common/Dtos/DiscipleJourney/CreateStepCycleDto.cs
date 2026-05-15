namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CreateStepCycleDto
    {
        public required string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public DateOnly? EnrollmentDeadline { get; set; }
    }
}

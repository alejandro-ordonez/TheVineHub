namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class AssignGuideDto
    {
        public required string CycleStaffId { get; set; }
        public IList<string> EnrollmentIds { get; set; } = [];
    }
}

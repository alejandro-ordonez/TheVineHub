namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class AssignGuideDto
    {
        public int CycleStaffId { get; set; }
        public IList<int> EnrollmentIds { get; set; } = [];
    }
}

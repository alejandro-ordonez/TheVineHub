namespace JMMinistry.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public int SchoolId { get; set; }
        public School? School { get; set; }

        public IList<CourseSchedule> Schedules { get; set; }
    }
}

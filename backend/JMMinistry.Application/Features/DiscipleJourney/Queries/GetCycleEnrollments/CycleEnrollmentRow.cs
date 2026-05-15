namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleEnrollments
{
    public record CycleEnrollmentRow
    {
        public int enrollment_id { get; set; }
        public string disciple_id { get; set; } = null!;
        public string disciple_name { get; set; } = null!;
        public int? cycle_staff_id { get; set; }
        public string? guide_name { get; set; }
        public int status { get; set; }
        public DateOnly enrolled_at { get; set; }
        public int attendance_count { get; set; }
    }
}

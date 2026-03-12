namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepDisciples
{
    public record StepDiscipleRow
    {
        public string disciple_id { get; set; } = null!;
        public string disciple_name { get; set; } = null!;
        public string disciple_last_name { get; set; } = null!;
        public string disciple_phone { get; set; } = string.Empty;
        public int disciple_gender { get; set; }
        public int? disciple_cell_id { get; set; }
        public string cell_name { get; set; } = string.Empty;
        public string cell_leader_name { get; set; } = string.Empty;
        public int step_status { get; set; }
        public DateOnly last_updated { get; set; }
        public string? cycle_name { get; set; }
        public int? enrollment_status { get; set; }
        public int? cycle_attendance_count { get; set; }
        public DateOnly? cycle_end_date { get; set; }
        public int? cycle_min_attendance { get; set; }
    }
}

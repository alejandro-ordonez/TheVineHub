namespace JMMinistry.Domain;

public partial class Assignment
{
    public int Id { get; set; }

    public int? SchoolId { get; set; }
    public School School { get; set; } = null!;

    public DateOnly DateRecorded { get; set; }

    public string Student { get; set; } = null!;

    public decimal Grade { get; set; }

    public string? Notes { get; set; }
}

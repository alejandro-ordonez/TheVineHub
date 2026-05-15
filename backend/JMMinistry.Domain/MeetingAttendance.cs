namespace JMMinistry.Domain;

public partial class MeetingAttendance
{
    public int Id { get; set; }

    public int MeetingId { get; set; }
    public Meeting? Meeting { get; set; }

    public DateOnly Date { get; set; }

    public IList<PersonalInfo> Attendees { get; set; } = null!;
}

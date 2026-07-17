using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.Users;

namespace TheVineHub.API.Features.Cells;

public class CellAttendanceDto
{
    [Column("id")]
    public string Id { get; set; } = string.Empty;
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("notes")]
    public string? Notes { get; set; }
    [Column("attendees")]
    public IList<BasicUserInfoDto> Attendees { get; set; } = [];
    [Column("missing_attendees")]
    public IList<BasicUserInfoDto> MissingAttendees { get; set; } = [];
}

using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;

namespace JMMinistry.Application.Features.Cells.Dtos;

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

public class AddCellAttendanceDto
{
    [Column("disciples")]
    public IList<string> Disciples { get; set; } = [];
    [Column("notes")]
    public string? Notes { get; set; }
}

public class UpdateCellAttendanceDto
{
    [Column("disciples")]
    public IList<string> Disciples { get; set; } = [];
    [Column("notes")]
    public string? Notes { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
}

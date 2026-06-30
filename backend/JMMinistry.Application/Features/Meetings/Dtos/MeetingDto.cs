using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.Meetings.Commands.CreateMeeting;
namespace JMMinistry.Application.Features.Meetings.Dtos;

public class MeetingDto : CreateMeetingDto
{
    [Column("meeting_id")]
    public string MeetingId { get; set; } = string.Empty;
}

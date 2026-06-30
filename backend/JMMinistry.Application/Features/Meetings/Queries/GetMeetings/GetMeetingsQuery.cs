using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.Meetings.Dtos;
using JMMinistry.Application.Features.Meetings.Commands.CreateMeeting;
using Mediator;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
{
    public class GetMeetingsQuery : IQuery<IList<MeetingDto>>
    {
        [Column("is_recurrent")]
        public bool IsRecurrent { get; set; }
    }
}

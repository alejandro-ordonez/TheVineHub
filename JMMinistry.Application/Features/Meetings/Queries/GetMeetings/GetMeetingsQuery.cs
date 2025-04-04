using JMMinistry.Common.Dtos.Meetings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
{
    public class GetMeetingsQuery : IRequest<IList<MeetingDto>>
    {
        public bool IsRecurrent { get; set; }
    }
}

using JMMinistry.Common.Dtos.Meetings.Enums;
using JMMinistry.Common.Dtos.User.Enums;
using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class MeetingAttendance
{
    public int Id { get; set; }

    public int MeetingId { get; set; }
    public Meeting? Meeting { get; set; }

    public DateOnly Date { get; set; }

    public IList<PersonalInfo> Attendees { get; set; } = null!;
}

using JMMinistry.Common.Dtos.Meetings.Enums;
using JMMinistry.Common.Dtos.User.Enums;
using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class MeetingAttendance
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public MeetingTypes MeetingType { get; set; }

    public string? PersonId { get; set; }
    public PersonalInfo Person { get; set; } = null!;

}

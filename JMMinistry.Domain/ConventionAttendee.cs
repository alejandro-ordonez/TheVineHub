using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class ConventionAttendee
{
    public int Id { get; set; }
    public int ConventionId { get; set; }
    public Convention Convention { get; set; } = null!;

    public string AttendeeId { get; set; } = null!;
    public PersonalInfo Attendee { get; set; } = null!;

    public string? InvitedById { get; set; }
    public PersonalInfo? InvitedBy { get; set; }

    public bool Confirmed { get; set; }

    public bool Paid { get; set; }

    public decimal Debt { get; set; }
}

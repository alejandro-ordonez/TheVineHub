using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class ClassAttendance
{
    public int Id { get; set; }


    public int ClassId { get; set; }
    public Class Class { get; set; } = null!;

    public DateOnly DateRecorded { get; set; }

    public ICollection<PersonalInfo> Attendees { get; set; } = Array.Empty<PersonalInfo>();
}

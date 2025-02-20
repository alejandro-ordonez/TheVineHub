using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class ClassAttendance
{
    public int Id { get; set; }
    public string ClassRefName { get; set; } = null!;
    public int ClassNumber { get; set; }
    public DateOnly DateOfClass { get; set; }

    public int ClassId { get; set; }
    public Class Class { get; set; } = null!;


    public IList<PersonalInfo> Attendees { get; set; } = Array.Empty<PersonalInfo>();
}

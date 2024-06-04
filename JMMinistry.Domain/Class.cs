using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class Class
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public string? ClassName { get; set; }

    public int ClassNumber { get; set; }


    public int SchoolId { get; set; }
    public School School { get; set; } = null!;


    public ICollection<ClassAttendance> ClassAttendances { get; set; } = Array.Empty<ClassAttendance>();
}

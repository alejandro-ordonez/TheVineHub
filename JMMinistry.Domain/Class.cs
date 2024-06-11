using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class Class
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int SchoolId { get; set; }
    public School School { get; set; } = null!;


    public ICollection<ClassAttendance> ClassAttendances { get; set; } = Array.Empty<ClassAttendance>();
}

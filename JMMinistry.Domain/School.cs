using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class School
{
    public int Id { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}

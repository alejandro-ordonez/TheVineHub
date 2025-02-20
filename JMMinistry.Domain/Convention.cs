using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public partial class Convention
{
    [Key]
    public int ConventionId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    IList<ConventionAttendee> ConventionAttendees { get; set; } = [];
}

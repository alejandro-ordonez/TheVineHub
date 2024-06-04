using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class Announcement
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}

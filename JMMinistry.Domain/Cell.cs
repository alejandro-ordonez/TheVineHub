using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class Cell
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool MainCell { get; set; }

    public required string PrimaryLeaderId { get; set; }
    public virtual PersonalInfo PrimaryLeader { get; set; } = null!;

    public required string SecondaryLeaderId { get; set; }
    public virtual PersonalInfo SecondaryLeader { get; set; } = null!;


    public ICollection<PersonalInfo> Disciples { get; set; } = Array.Empty<PersonalInfo>();
}

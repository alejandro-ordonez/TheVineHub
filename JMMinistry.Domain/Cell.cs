using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class Cell
{
    public int CellId { get; set; }
    public string? Name { get; set; }
    public bool MainCell { get; set; }

    public string LeaderId { get; set; } = null!;
    public virtual PersonalInfo Leader { get; set; } = null!;


    public ICollection<PersonalInfo> Disciples { get; set; } = Array.Empty<PersonalInfo>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public partial class Cell
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool MainCell { get; set; }

    [MaxLength(2)]
    public ICollection<PersonalInfo> Leaders { get; set; } = Array.Empty<PersonalInfo>();
    public ICollection<PersonalInfo> Disciples { get; set; } = Array.Empty<PersonalInfo>();
}

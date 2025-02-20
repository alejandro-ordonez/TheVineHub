using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public partial class Cell
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool MainCell { get; set; }
    public required string Address { get; set; }

    [MaxLength(2)]
    public IList<PersonalInfo> Leaders { get; set; } = [];
    public IList<PersonalInfo> Disciples { get; set; } = [];
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public class Gained
{
    [Required]
    [Key]
    public int GainedId { get; set; }
    public string PersonId { get; set; } = null!;
    public PersonalInfo Person { get; set; } = null!;

    public string? InvitedById { get; set; }
    public PersonalInfo InvitedBy { get; set; } = null!;

    [Required]
    public DateOnly Date { get; set; }

    public List<GainedEvent> Events { get; set; } = [];
}

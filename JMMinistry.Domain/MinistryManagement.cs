using JMMinistry.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public partial class MinistryManagement
{
    public int Id { get; set; }

    [Required]
    public int MinistryId { get; set; }
    public Ministry Ministry { get; set; } = null!;

    public string MemberId { get; set; } = null!;
    public PersonalInfo Member { get; set; } = null!;

    public MemberType MemberType { get; set; }

    public bool Active { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}

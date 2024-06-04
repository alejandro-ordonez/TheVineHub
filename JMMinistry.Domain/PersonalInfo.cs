using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public partial class PersonalInfo: IdentityUser
{
    [Key]
    public string Document { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public string Neighborhood { get; set; } = null!;

    public string? Address { get; set; }

    public DateOnly Birthday { get; set; }

    public DateTime LastAccess { get; set; }

    public int? GainedId { get; set; }
    /// <summary>
    /// Record when the person was gained.
    /// </summary>
    public Gained? GainedRecord { get; set; } = null!;


    public int? CellId { get; set; }
    /// <summary>
    /// Cell to which the person belongs to
    /// </summary>
    public Cell? Cell { get; set; }

    public ICollection<Cell> Cells { get; set; } = Array.Empty<Cell>();
    public ICollection<MeetingAttendance> MeetingAttendances { get; set; } = Array.Empty<MeetingAttendance>();
    public ICollection<ClassAttendance> ClassAttendances { get; set; } = Array.Empty<ClassAttendance>();
    public ICollection<ClassStudent> Classes { get; set; } = Array.Empty<ClassStudent>();
    public ICollection<ConventionAttendee> Conventions { get; set; } = Array.Empty<ConventionAttendee>();
    public ICollection<ConventionAttendee> ConventionInvites { get; set; } = Array.Empty<ConventionAttendee>();
    public ICollection<CellAttendance> CellAttendances { get; set; } = Array.Empty<CellAttendance>();

    public ICollection<Role> Roles { get; set; } = Array.Empty<Role>();

    /// <summary>
    /// Gained by the person
    /// </summary>
    public ICollection<Gained> Gained { get; set; } = Array.Empty<Gained>();
    


}

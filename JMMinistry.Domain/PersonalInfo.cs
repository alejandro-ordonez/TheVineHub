using JMMinistry.Common.Dtos.User.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Domain;

[Index(nameof(Name), nameof(LastName))]
public partial class PersonalInfo: IdentityUser<string>
{
    public PersonalInfo()
    {
        SecurityStamp = Guid.NewGuid().ToString();
    }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? City { get; set; }

    public string? Locality { get; set; }

    public string? Neighborhood { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
    public EducationalLevel? EducationalLevel { get; set; }
    public string? Profession { get; set; }
    public string? Occupation { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public DateOnly? Birthday { get; set; }

    public Gender? Gender { get; set; }

    public MinistryStatus MinistryStatus { get; set; }

    public DateTime? LastAccess { get; set; }

    public int? GainedId { get; set; }
    /// <summary>
    /// Record when the person was gained.
    /// </summary>
    public Gained? GainedRecord { get; set; }


    public int? CellId { get; set; }
    /// <summary>
    /// Cell to which the person belongs to
    /// </summary>
    public Cell? Cell { get; set; }

    public IList<Cell> Cells { get; set; } = [];

    public IList<MeetingAttendance> MeetingAttendances { get; set; } = [];
    public IList<CellAttendance> CellAttendances { get; set; } = [];
    public IList<ClassAttendance> ClassAttendances { get; set; } = [];


    public IList<ClassStudent> Classes { get; set; } = [];
    public IList<ConventionAttendee> Conventions { get; set; } = [];
    public IList<ConventionAttendee> ConventionInvites { get; set; } = [];
    

    public virtual IList<PersonalInfoRole> UserRoles { get; set; } = [];

    /// <summary>
    /// Gained by the person
    /// </summary>
    public IList<Gained> Gained { get; set; } = [];
    


}

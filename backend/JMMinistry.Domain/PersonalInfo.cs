using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain.DiscipleJourney;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Domain;

public partial class PersonalInfo : IdentityUser<string>
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

    public string? PhotoPath { get; set; }
    public EducationalLevel? EducationalLevel { get; set; }
    public string? Profession { get; set; }
    public string? Occupation { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public DateOnly? Birthday { get; set; }

    public Gender? Gender { get; set; }

    public DateTime? LastAccess { get; set; }

    public IList<MeetingAttendance> MeetingAttendances { get; set; } = [];
    public IList<CellAttendance> CellAttendances { get; set; } = [];

    public virtual IList<PersonalInfoRole> UserRoles { get; set; } = [];
}

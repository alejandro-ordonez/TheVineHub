using JMMinistry.Domain;
using JMMinistry.Domain.Location;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Services
{
    public interface IJmDbContext
    {
        DbSet<Announcement> Announcements { get; set; }

        DbSet<Assignment> Assignments { get; set; }

        DbSet<Cell> Cells { get; set; }
        DbSet<CellAttendance> CellAttendances { get; set; }

        DbSet<Class> Classes { get; set; }

        DbSet<ClassAttendance> ClassAttendances { get; set; }

        DbSet<ClassStudent> ClassStudents { get; set; }

        DbSet<Convention> Conventions { get; set; }

        DbSet<ConventionAttendee> ConventionAttendees { get; set; }

        DbSet<Event> Events { get; set; }

        DbSet<Gained> Gained { get; set; }

        DbSet<Meeting> Meetings { get; set; }

        DbSet<MeetingAttendance> MeetingAttendances { get; set; }

        DbSet<Role> Ministries { get; set; }

        DbSet<PersonalInfo> PersonalInfo { get; set; }

        DbSet<School> Schools { get; set; }

        DbSet<City> Cities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

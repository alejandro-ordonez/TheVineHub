using JMMinistry.Domain;
using JMMinistry.Domain.Discipleship;
using JMMinistry.Domain.DiscipleJourney;
using JMMinistry.Domain.Location;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Services
{
    public interface IJmDbContext
    {
        DbSet<Announcement> Announcements { get; set; }

        DbSet<Cell> Cells { get; set; }
        DbSet<CellAttendance> CellAttendances { get; set; }

        DbSet<Convention> Conventions { get; set; }

        DbSet<ConventionAttendee> ConventionAttendees { get; set; }

        DbSet<DiscipleshipNote> DiscipleshipNotes { get; set; }

        DbSet<DiscipleshipNoteEntry> DiscipleshipNoteEntries { get; set; }

        DbSet<DiscipleStep> DiscipleSteps { get; set; }

        DbSet<StepCompletion> StepCompletions { get; set; }

        DbSet<StepCycle> StepCycles { get; set; }
        DbSet<CycleSession> CycleSessions { get; set; }
        DbSet<CycleStaff> CycleStaff { get; set; }
        DbSet<CycleEnrollment> CycleEnrollments { get; set; }
        DbSet<CycleAttendance> CycleAttendances { get; set; }

        DbSet<Event> Events { get; set; }


        DbSet<Meeting> Meetings { get; set; }

        DbSet<MeetingAttendance> MeetingAttendances { get; set; }

        DbSet<Role> Ministries { get; set; }

        DbSet<PersonalInfo> PersonalInfo { get; set; }

        DbSet<City> Cities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<T?> ExecuteScalarFunctionAsync<T>(string functionCall, CancellationToken ct, params object[] parameters);

        Task<List<T>> ExecuteTableFunctionAsync<T>(string functionCall, CancellationToken ct, params object[] parameters);
    }
}

using JMMinistry.Application.Services;
using JMMinistry.Domain;
using JMMinistry.Domain.Discipleship;
using JMMinistry.Domain.DiscipleJourney;
using JMMinistry.Domain.Location;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Infrastructure.Persistence;

public partial class JmDbContext : IdentityDbContext<PersonalInfo, Role, string>, IJmDbContext
{
    public JmDbContext()
    {
    }

    public JmDbContext(DbContextOptions<JmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Cell> Cells { get; set; }
    public virtual DbSet<CellAttendance> CellAttendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }
    public virtual DbSet<ClassAttendance> ClassAttendances { get; set; }

    public virtual DbSet<ClassStudent> ClassStudents { get; set; }

    public virtual DbSet<Convention> Conventions { get; set; }
    public virtual DbSet<ConventionAttendee> ConventionAttendees { get; set; }

    public virtual DbSet<DiscipleshipNote> DiscipleshipNotes { get; set; }
    public virtual DbSet<DiscipleshipNoteEntry> DiscipleshipNoteEntries { get; set; }

    public virtual DbSet<DiscipleStep> DiscipleSteps { get; set; }

    public virtual DbSet<StepCompletion> StepCompletions { get; set; }

    public virtual DbSet<StepCycle> StepCycles { get; set; }
    public virtual DbSet<CycleSession> CycleSessions { get; set; }
    public virtual DbSet<CycleStaff> CycleStaff { get; set; }
    public virtual DbSet<CycleEnrollment> CycleEnrollments { get; set; }
    public virtual DbSet<CycleAttendance> CycleAttendances { get; set; }

    public virtual DbSet<Event> Events { get; set; }


    public virtual DbSet<Meeting> Meetings { get; set; }
    public virtual DbSet<MeetingAttendance> MeetingAttendances { get; set; }

    public virtual DbSet<Role> Ministries { get; set; }

    public virtual DbSet<PersonalInfo> PersonalInfo { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public async Task<T?> ExecuteScalarFunctionAsync<T>(string functionCall, CancellationToken ct, params object[] parameters)
    {
        return await Database.SqlQueryRaw<T>(functionCall, parameters).FirstOrDefaultAsync(ct);
    }

    public async Task<List<T>> ExecuteTableFunctionAsync<T>(string functionCall, CancellationToken ct, params object[] parameters)
    {
        return await Database.SqlQueryRaw<T>(functionCall, parameters).ToListAsync(ct);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .HasPostgresEnum("meeting_type", ["one", "rocks", "family"])
            .HasPostgresEnum("member_type", ["coordinator", "staff", "assistant"])
            .HasPostgresEnum("ministry_status", ["guess", "gained", "consolidating", "disciple", "leader"]);

        builder.Entity<PersonalInfo>(user =>
        {
            user.HasMany(e => e.UserRoles)
                .WithOne(e => e.PersonalInfo)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            user.ToTable(nameof(PersonalInfo));
        });

        builder.Entity<Role>(b =>
        {
            // Each Role can have many entries in the UserRole join table
            b.HasMany(role => role.UserRoles)
                .WithOne(user => user.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            b.ToTable(nameof(Role));
        });

        builder.Entity<Cell>()
            .HasMany(c => c.Disciples)
            .WithOne(p => p.Cell)
            .HasForeignKey(p => p.CellId);


        builder.Entity<ConventionAttendee>()
            .HasOne(c => c.InvitedBy)
            .WithMany(p => p.ConventionInvites)
            .HasForeignKey(c => c.InvitedById);

        builder.Entity<ConventionAttendee>()
            .HasOne(c => c.Attendee)
            .WithMany(p => p.Conventions)
            .HasForeignKey(c => c.AttendeeId);

        builder.Entity<Locality>()
            .ToTable("Localities");

        builder.Entity<StepCompletion>(step =>
        {
            step.HasOne(s => s.Disciple)
                .WithMany(p => p.StepCompletions)
                .HasForeignKey(s => s.DiscipleId)
                .OnDelete(DeleteBehavior.Restrict);

            step.HasOne(s => s.Leader)
                .WithMany(p => p.SupervisedStepCompletions)
                .HasForeignKey(s => s.LeaderId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<DiscipleshipNote>(note =>
        {
            note.HasOne(n => n.Disciple)
                .WithMany()
                .HasForeignKey(n => n.DiscipleId)
                .OnDelete(DeleteBehavior.Restrict);

            note.HasOne(n => n.Leader)
                .WithMany()
                .HasForeignKey(n => n.LeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            note.HasMany(n => n.Entries)
                .WithOne(e => e.Note)
                .HasForeignKey(e => e.NoteId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<DiscipleshipNoteEntry>(entry =>
        {
            entry.HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<DiscipleStep>(step =>
        {
            step.HasMany(s => s.DiscipleStepRequirements)
                .WithMany()
                .UsingEntity(j => j.ToTable("DiscipleStepRequirement"));

            step.HasMany(s => s.SubSteps)
                .WithOne(s => s.ParentStep)
                .HasForeignKey(s => s.ParentStepId)
                .OnDelete(DeleteBehavior.Cascade);

            step.HasMany(s => s.Cycles)
                .WithOne(c => c.DiscipleStep)
                .HasForeignKey(c => c.DiscipleStepId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<StepCycle>(cycle =>
        {
            cycle.HasIndex(c => c.DiscipleStepId);
            cycle.HasIndex(c => new { c.DiscipleStepId, c.IsOpen });

            cycle.HasMany(c => c.Sessions)
                .WithOne(s => s.StepCycle)
                .HasForeignKey(s => s.StepCycleId)
                .OnDelete(DeleteBehavior.Cascade);

            cycle.HasMany(c => c.Enrollments)
                .WithOne(e => e.StepCycle)
                .HasForeignKey(e => e.StepCycleId)
                .OnDelete(DeleteBehavior.Cascade);

            cycle.HasMany(c => c.Staff)
                .WithOne(s => s.StepCycle)
                .HasForeignKey(s => s.StepCycleId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<CycleSession>(session =>
        {
            session.HasIndex(s => s.StepCycleId);

            session.HasMany(s => s.Attendances)
                .WithOne(a => a.CycleSession)
                .HasForeignKey(a => a.CycleSessionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<CycleStaff>(staff =>
        {
            staff.HasIndex(s => new { s.StepCycleId, s.PersonId }).IsUnique();

            staff.HasOne(s => s.Person)
                .WithMany()
                .HasForeignKey(s => s.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            staff.HasMany(s => s.Enrollments)
                .WithOne(e => e.CycleStaff)
                .HasForeignKey(e => e.CycleStaffId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<CycleEnrollment>(enrollment =>
        {
            enrollment.HasIndex(e => new { e.StepCycleId, e.DiscipleId }).IsUnique();
            enrollment.HasIndex(e => e.CycleStaffId);

            enrollment.HasOne(e => e.Disciple)
                .WithMany()
                .HasForeignKey(e => e.DiscipleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<CycleAttendance>(attendance =>
        {
            attendance.HasIndex(a => new { a.CycleSessionId, a.DiscipleId }).IsUnique();

            attendance.HasOne(a => a.Disciple)
                .WithMany()
                .HasForeignKey(a => a.DiscipleId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}

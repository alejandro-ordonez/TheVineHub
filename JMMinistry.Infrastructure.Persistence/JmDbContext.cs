using JMMinistry.Application.Services;
using JMMinistry.Domain;
using JMMinistry.Domain.Discipleship;
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

    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Gained> Gained { get; set; }


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

        builder.Entity<Gained>()
            .HasOne(g => g.Person)
            .WithOne(p => p.GainedRecord)
            .HasForeignKey<PersonalInfo>(p => p.GainedId);

        builder.Entity<Gained>()
            .HasOne(g => g.InvitedBy)
            .WithMany(p => p.Gained)
            .HasForeignKey(g => g.InvitedById);

        builder.Entity<Locality>()
            .ToTable("Localities");

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
    }
}

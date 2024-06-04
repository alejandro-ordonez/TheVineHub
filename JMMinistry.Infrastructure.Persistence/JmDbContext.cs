using System;
using System.Collections.Generic;
using JMMinistry.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Infrastructure.Persistence;

public partial class JmDbContext : IdentityDbContext<PersonalInfo, Role, string>
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

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassAttendance> ClassAttendances { get; set; }

    public virtual DbSet<ClassStudent> ClassStudents { get; set; }

    public virtual DbSet<Convention> Conventions { get; set; }

    public virtual DbSet<ConventionAttendee> ConventionAttendees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gained> Gaineds { get; set; }

    public virtual DbSet<MeetingAttendance> MeetingAttendances { get; set; }

    public virtual DbSet<Role> Ministries { get; set; }

    public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .HasPostgresEnum("meeting_type", ["one", "rocks", "family"])
            .HasPostgresEnum("member_type", ["coordinator", "staff", "assistant"])
            .HasPostgresEnum("ministry_status", ["guess", "gained", "consolidating", "disciple", "leader"]);

        modelBuilder.Entity<Cell>()
            .HasMany(c => c.Disciples)
            .WithOne(p => p.Cell)
            .HasForeignKey(p => p.CellId);

        modelBuilder.Entity<Cell>()
            .HasOne(c => c.Leader)
            .WithMany(p => p.Cells)
            .HasForeignKey(c => c.LeaderId);

        modelBuilder.Entity<ConventionAttendee>()
            .HasOne(c => c.InvitedBy)
            .WithMany(p => p.ConventionInvites)
            .HasForeignKey(c => c.InvitedById);

        modelBuilder.Entity<ConventionAttendee>()
            .HasOne(c => c.Attendee)
            .WithMany(p => p.Conventions)
            .HasForeignKey(c => c.AttendeeId);

        modelBuilder.Entity<Gained>()
            .HasOne(g => g.Person)
            .WithOne(p => p.GainedRecord)
            .HasForeignKey<PersonalInfo>(p => p.GainedId);

        modelBuilder.Entity<Gained>()
            .HasOne(g => g.InvitedBy)
            .WithMany(p => p.Gained)
            .HasForeignKey(g => g.InvitedById);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

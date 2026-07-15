using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Sessions;
using TheVineHub.API.Features.DiscipleJourney.Staff;
using TheVineHub.API.Features.DiscipleJourney.Attendance;
using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users;
using Xunit;
using FluentAssertions;
using SurrealDb.Net.Models;

namespace TheVineHub.IntegrationTests.Features.DiscipleJourney;

public class DiscipleJourneyIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task CreateDiscipleStep_ShouldSuccessfullyCreateStep()
    {
        // Arrange
        var command = new CreateDiscipleStepCommand
        {
            Name = "Step 1: Introduction",
            Description = "Initial step in the journey",
            StepCategory = StepCategory.Gain,
            RequiresCycle = true,
            RequiresAdminApproval = false
        };

        // Act
        var result = await Mediator.Send(command);

        // Assert
        result.Should().NotBeNull();
        result.Id?.Table.Should().Be("disciple_step");
        result.Name.Should().Be("Step 1: Introduction");

        var steps = await Mediator.Send(new GetDiscipleStepsQuery());
        steps.Should().Contain(s => s.Id == result.Id);
    }

    [Fact]
    public async Task CreateStepCycle_ShouldSuccessfullyCreateCycle()
    {
        // Arrange
        var step = await Mediator.Send(new CreateDiscipleStepCommand
        {
            Name = "Step for Cycle",
            Description = "Test Step",
            StepCategory = StepCategory.Consolidate,
            RequiresCycle = true
        });

        var command = new CreateStepCycleCommand
        {
            StepId = step.Id?.DeserializeId<string>()!,
            Name = "Cycle 2024-Q1",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(3)),
            MinAttendanceRequired = 8,
            EnrollmentDeadline = DateOnly.FromDateTime(DateTime.Today.AddDays(7))
        };

        // Act
        var result = await Mediator.Send(command);

        // Assert
        result.Should().NotBeNull();
        result.Id?.Table.Should().Be("cycle");
        result.Name.Should().Be("Cycle 2024-Q1");
        result.DiscipleStepId?.ToString().Should().Be(step.Id?.ToString());
    }

    [Fact]
    public async Task EnrollDisciples_ShouldSuccessfullyEnrollDisciplesInCycle()
    {
        // Arrange
        var step = await Mediator.Send(new CreateDiscipleStepCommand
        {
            Name = "Step for Enrollment",
            Description = "Test Step",
            StepCategory = StepCategory.Disciple,
            RequiresCycle = true
        });

        var cycle = await Mediator.Send(new CreateStepCycleCommand
        {
            StepId = step.Id?.DeserializeId<string>()!,
            Name = "Enrollment Cycle",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(3)),
            MinAttendanceRequired = 5
        });

        var leaderId = "leader_enroll_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Leader",
            LastName = "Enroll",
            Email = "leader_enroll@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var discipleId = "disciple_enroll_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Disciple",
            LastName = "Enroll",
            Email = "disciple_enroll@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var command = new EnrollDisciplesCommand
        {
            CycleId = cycle.Id?.DeserializeId<string>()!,
            LeaderId = leaderId,
            DiscipleIds = new List<string> { discipleId }
        };

        // Act
        await Mediator.Send(command);

        // Assert
        var checkResult = await DbSession.Query($"RETURN count(SELECT * FROM enrolled WHERE out = {cycle.Id} AND in = type::record('user', {discipleId}));");
        var count = checkResult.GetValue<int>(0);
        count.Should().Be(1);
    }

    [Fact]
    public async Task ManageSessions_ShouldSuccessfullyCreateGetAndDeleteSessions()
    {
        // Arrange
        var step = await Mediator.Send(new CreateDiscipleStepCommand
        {
            Name = "Step for Sessions",
            Description = "Test Step",
            StepCategory = StepCategory.Gain,
            RequiresCycle = true
        });

        var cycle = await Mediator.Send(new CreateStepCycleCommand
        {
            StepId = step.Id!.DeserializeId<string>()!,
            Name = "Session Cycle",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(3)),
            MinAttendanceRequired = 5
        });

        var createCommand = new CreateCycleSessionCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            Date = DateOnly.FromDateTime(DateTime.Today),
            Topic = "Discipleship Introduction Topic"
        };

        var session = await Mediator.Send(createCommand);

        session.Should().NotBeNull();
        session.Topic.Should().Be("Discipleship Introduction Topic");
        session.Id.Should().StartWith("cycle_session:");

        // 2. Get sessions
        var sessions = await Mediator.Send(new GetCycleSessionsQuery
        {
            CycleId = cycle.Id!.DeserializeId<string>()!
        });

        sessions.Should().Contain(s => s.Id == session.Id);

        // 3. Delete session
        await Mediator.Send(new DeleteCycleSessionCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            SessionId = session.Id
        });

        var sessionsAfterDelete = await Mediator.Send(new GetCycleSessionsQuery
        {
            CycleId = cycle.Id!.DeserializeId<string>()!
        });

        sessionsAfterDelete.Should().NotContain(s => s.Id == session.Id);
    }

    [Fact]
    public async Task ManageStaff_ShouldSuccessfullyAddGetAndRemoveStaff()
    {
        // Arrange
        var step = await Mediator.Send(new CreateDiscipleStepCommand
        {
            Name = "Step for Staff",
            Description = "Test Step",
            StepCategory = StepCategory.Gain,
            RequiresCycle = true
        });

        var cycle = await Mediator.Send(new CreateStepCycleCommand
        {
            StepId = step.Id!.DeserializeId<string>()!,
            Name = "Staff Cycle",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(3)),
            MinAttendanceRequired = 5
        });

        var staffId = "staff_member_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{staffId}",
            Name = "Staff",
            LastName = "One",
            Email = "staff1@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        // 1. Add Staff
        var addCommand = new AddCycleStaffCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            PersonId = staffId,
            Role = CycleStaffRole.Guide
        };

        var staff = await Mediator.Send(addCommand);

        staff.Should().NotBeNull();
        staff.Role.Should().Be(CycleStaffRole.Guide);
        staff.Id.Should().StartWith("guides:");

        // 2. Get Staff
        var staffList = await Mediator.Send(new GetCycleStaffQuery
        {
            CycleId = cycle.Id!.DeserializeId<string>()!
        });

        staffList.Should().Contain(s => s.Id == staff.Id);

        // 3. Remove Staff
        await Mediator.Send(new RemoveCycleStaffCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            StaffId = staff.Id
        });

        var staffListAfterDelete = await Mediator.Send(new GetCycleStaffQuery
        {
            CycleId = cycle.Id!.DeserializeId<string>()!
        });

        staffListAfterDelete.Should().NotContain(s => s.Id == staff.Id);
    }

    [Fact]
    public async Task ManageEnrollmentAndAttendance_ShouldSuccessfullyPerformActions()
    {
        // Arrange
        var step = await Mediator.Send(new CreateDiscipleStepCommand
        {
            Name = "Full Workflow Step",
            Description = "Test Step",
            StepCategory = StepCategory.Gain,
            RequiresCycle = true
        });

        var cycle = await Mediator.Send(new CreateStepCycleCommand
        {
            StepId = step.Id!.DeserializeId<string>()!,
            Name = "Workflow Cycle",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(3)),
            MinAttendanceRequired = 5
        });

        var leaderId = "flow_leader_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Flow",
            LastName = "Leader",
            Email = "flowleader@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var discipleId = "flow_disciple_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Flow",
            LastName = "Disciple",
            Email = "flowdisciple@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        // 1. Enroll disciple
        await Mediator.Send(new EnrollDisciplesCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            LeaderId = leaderId,
            DiscipleIds = new List<string> { discipleId }
        });

        // Add leader as Coordinator so they are authorized to get enrollments
        await Mediator.Send(new AddCycleStaffCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            PersonId = leaderId,
            Role = CycleStaffRole.Coordinator
        });

        // Get enrollment ID
        var enrollments = await Mediator.Send(new GetCycleEnrollmentsQuery
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            RequestorId = $"user:{leaderId}"
        });

        enrollments.Should().NotBeEmpty();
        var enrollment = enrollments.First(e => e.DiscipleId == $"user:{discipleId}");
        enrollment.Status.Should().Be(StepStatus.InProgress);

        // 2. Update Enrollment Status
        await Mediator.Send(new UpdateEnrollmentStatusCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            EnrollmentId = enrollment.Id,
            Status = StepStatus.Completed
        });

        var enrollmentsAfterUpdate = await Mediator.Send(new GetCycleEnrollmentsQuery
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            RequestorId = $"user:{leaderId}"
        });
        enrollmentsAfterUpdate.First(e => e.DiscipleId == $"user:{discipleId}").Status.Should().Be(StepStatus.Completed);

        // 3. Create Session and Record Attendance
        var session = await Mediator.Send(new CreateCycleSessionCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            Date = DateOnly.FromDateTime(DateTime.Today),
            Topic = "Attendance Session"
        });

        await Mediator.Send(new RecordCycleAttendanceCommand
        {
            CycleId = cycle.Id!.DeserializeId<string>()!,
            SessionId = session.Id,
            DiscipleIds = new List<string> { discipleId }
        });

        var attendanceList = await Mediator.Send(new GetCycleAttendanceQuery
        {
            CycleId = cycle.Id!.DeserializeId<string>()!
        });

        attendanceList.Should().NotBeEmpty();
        var attSession = attendanceList.FirstOrDefault(a => a.SessionId == session.Id);
        attSession.Should().NotBeNull();
        attSession!.Attendees.Should().Contain(a => a.DiscipleId == $"user:{discipleId}" && a.Attended);
    }
}

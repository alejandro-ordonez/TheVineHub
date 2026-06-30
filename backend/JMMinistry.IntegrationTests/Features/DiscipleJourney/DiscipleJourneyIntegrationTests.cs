using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetDiscipleSteps;
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Enums;
using Xunit;
using FluentAssertions;
using SurrealDb.Net.Models;

namespace JMMinistry.IntegrationTests.Features.DiscipleJourney;

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
            Id = RecordId.From("user", leaderId),
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
            Id = RecordId.From("user", discipleId),
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
        // Verification would typically involve checking enrollment records in DB
        var checkResult = await DbSession.Query($"RETURN count(SELECT * FROM enrolled_to WHERE out = {cycle.Id} AND in = type::record('user', {discipleId}));");
        var count = checkResult.GetValue<int>(0);
        count.Should().Be(1);
    }
}

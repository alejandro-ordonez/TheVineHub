using TheVineHub.API.Features.Cells.UpsertCell;
using TheVineHub.API.Features.Cells.AddDisciples;
using TheVineHub.API.Features.Cells.RemoveDisciple;
using TheVineHub.API.Features.Cells.RecordAttendance;
using TheVineHub.API.Features.Cells.UpdateAttendance;
using TheVineHub.API.Features.Cells.GetCells;
using TheVineHub.API.Features.Cells.GetDisciples;
using TheVineHub.API.Features.Cells.GetCellAttendances;
using TheVineHub.API.Features.Cells;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users;
using Xunit;
using FluentAssertions;
using SurrealDb.Net.Models;

namespace TheVineHub.IntegrationTests.Features.Cells;

public class CellIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task UpsertCell_ShouldSuccessfullyCreateCell()
    {
        // Arrange
        var leaderId = "cell_leader_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Cell",
            LastName = "Leader",
            Email = "leader@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var command = new UpsertCellCommand
        {
            Document = leaderId,
            Name = "New Cell Group",
            Description = "A new cell group",
            MainCell = true,
            Address = "Cell Address",
            Day = DayOfWeek.Wednesday,
            OpeningDate = DateOnly.FromDateTime(DateTime.Today)
        };

        // Act
        var result = await Mediator.Send(command);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBeNull();
        result.Id!.Table.Should().Be("cell");
        result.Name.Should().Be("New Cell Group");
    }

    [Fact]
    public async Task AddDisciples_ShouldSuccessfullyAddDisciplesToCell()
    {
        // Arrange
        var leaderId = "cell_leader_2";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Cell",
            LastName = "Leader",
            Email = "leader2@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var cell = await Mediator.Send(new UpsertCellCommand
        {
            Document = leaderId,
            Name = "Cell for Disciples",
            Description = "Test Cell",
            Address = "Address",
            MainCell = false
        });

        var discipleId = "disciple_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Disciple",
            LastName = "One",
            Email = "disciple1@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var command = new AddDisciplesCommand
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            Documents = new List<string> { discipleId }
        };

        // Act
        var result = await Mediator.Send(command);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result[0].FullName.Should().Contain("Disciple One");

        var disciples = await Mediator.Send(new GetDisciplesQuery
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            RequestorId = $"user:{leaderId}"
        });

        disciples.Should().HaveCount(1);
    }

    [Fact]
    public async Task RemoveDisciple_ShouldSuccessfullyRemoveDiscipleFromCell()
    {
        // Arrange
        var leaderId = "cell_leader_3";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Cell",
            LastName = "Leader",
            Email = "leader3@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var cell = await Mediator.Send(new UpsertCellCommand
        {
            Document = leaderId,
            Name = "Cell for Removal",
            Description = "Test Cell",
            Address = "Address",
            MainCell = false
        });

        var discipleId = "disciple_to_remove";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Disciple",
            LastName = "ToRemove",
            Email = "toremove@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        await Mediator.Send(new AddDisciplesCommand
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            Documents = new List<string> { discipleId }
        });

        // Act
        var result = await Mediator.Send(new RemoveDiscipleCommand
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            Document = discipleId
        });

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();

        var disciples = await Mediator.Send(new GetDisciplesQuery
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            RequestorId = $"user:{leaderId}"
        });

        disciples.Should().BeEmpty();
    }

    [Fact]
    public async Task ManageAttendance_ShouldSuccessfullyRecordGetAndUpdateCellMeetings()
    {
        // Arrange
        var leaderId = "cell_leader_4";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Cell",
            LastName = "Leader 4",
            Email = "leader4@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var cell = await Mediator.Send(new UpsertCellCommand
        {
            Document = leaderId,
            Name = "Cell for Attendance",
            Description = "Test Cell",
            Address = "Address",
            MainCell = false
        });

        var discipleId = "disciple_for_attendance";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Disciple",
            LastName = "Attendance",
            Email = "disc_att@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        await Mediator.Send(new AddDisciplesCommand
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            Documents = new List<string> { discipleId }
        });

        // 1. Record Attendance
        var recordCommand = new RecordAttendanceCommand
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            RequestorId = $"user:{leaderId}",
            Attendees = new List<string> { discipleId },
            Notes = "First cell meeting notes"
        };

        var recorded = await Mediator.Send(recordCommand);

        recorded.Should().NotBeNull();
        recorded!.Notes.Should().Be("First cell meeting notes");
        recorded.Attendees.Should().Contain(a => a.Id != null && a.Id.DeserializeId<string>() == discipleId);

        // 2. Get Cell Attendances
        var attendances = await Mediator.Send(new GetCellAttendancesQuery
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            RequestorId = $"user:{leaderId}"
        });

        attendances.Should().NotBeEmpty();
        attendances.Should().Contain(a => a.Id == recorded.Id);

        // 3. Update Attendance
        var updateCommand = new UpdateAttendanceCommand
        {
            CellId = cell.Id!.DeserializeId<string>()!,
            AttendanceId = recorded.Id,
            RequestorId = $"user:{leaderId}",
            Attendees = new List<string>(), // no attendees this time
            Notes = "Updated cell meeting notes",
            Date = DateTime.UtcNow
        };

        var updated = await Mediator.Send(updateCommand);

        updated.Should().NotBeNull();
        updated!.Notes.Should().Be("Updated cell meeting notes");
        updated.Attendees.Should().BeEmpty();
        updated.MissingAttendees.Should().Contain(a => a.Id != null && a.Id.DeserializeId<string>() == discipleId);
    }

    [Fact]
    public async Task GetCells_ShouldReturnCellsWhereUserIsLeader()
    {
        // Arrange
        var leaderId = "cell_leader_5";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Cell",
            LastName = "Leader 5",
            Email = "leader5@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var cell = await Mediator.Send(new UpsertCellCommand
        {
            Document = leaderId,
            Name = "Cell of Leader 5",
            Description = "Test Cell",
            Address = "Address",
            MainCell = false
        });

        // Act
        var result = await Mediator.Send(new GetCellsQuery
        {
            Document = leaderId
        });

        // Assert
        result.Should().NotBeEmpty();
        result.Should().Contain(c => c.Name == "Cell of Leader 5");
    }
}

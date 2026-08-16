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

    [Fact]
    public async Task GetCells_ShouldReturnDaughterCells_WhenUserHasMultiplyingDisciples()
    {
        // Arrange
        var level1LeaderId = "multi_leader_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{level1LeaderId}",
            Name = "Level 1",
            LastName = "Leader",
            Email = "multi1@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var cell1 = await Mediator.Send(new UpsertCellCommand
        {
            Document = level1LeaderId,
            Name = "Cell Level 1",
            Description = "Test Cell 1",
            Address = "Address",
            MainCell = false
        });

        var level2LeaderId = "multi_leader_2";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{level2LeaderId}",
            Name = "Level 2",
            LastName = "Leader",
            Email = "multi2@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        // Level 2 leader is a disciple in Cell 1
        await Mediator.Send(new AddDisciplesCommand
        {
            CellId = cell1.Id!.DeserializeId<string>()!,
            Documents = new List<string> { level2LeaderId }
        });

        var cell2 = await Mediator.Send(new UpsertCellCommand
        {
            Document = level2LeaderId,
            Name = "Cell Level 2",
            Description = "Test Cell 2",
            Address = "Address",
            MainCell = false
        });

        var level3LeaderId = "multi_leader_3";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{level3LeaderId}",
            Name = "Level 3",
            LastName = "Leader",
            Email = "multi3@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        // Level 3 leader is a disciple in Cell 2
        await Mediator.Send(new AddDisciplesCommand
        {
            CellId = cell2.Id!.DeserializeId<string>()!,
            Documents = new List<string> { level3LeaderId }
        });

        var cell3 = await Mediator.Send(new UpsertCellCommand
        {
            Document = level3LeaderId,
            Name = "Cell Level 3",
            Description = "Test Cell 3",
            Address = "Address",
            MainCell = false
        });

        // Act
        var result = await Mediator.Send(new GetCellsQuery
        {
            Document = level1LeaderId
        });

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);

        var returnedCell1 = result.FirstOrDefault(c => c.Name == "Cell Level 1");
        returnedCell1.Should().NotBeNull();
        returnedCell1!.Level.Should().Be(1);

        var returnedCell2 = result.FirstOrDefault(c => c.Name == "Cell Level 2");
        returnedCell2.Should().NotBeNull();
        returnedCell2!.Level.Should().Be(2);
        returnedCell2.ParentCellId.Should().Be(cell1.Id!.ToString());

        var returnedCell3 = result.FirstOrDefault(c => c.Name == "Cell Level 3");
        returnedCell3.Should().NotBeNull();
        returnedCell3!.Level.Should().Be(3);
        returnedCell3.ParentCellId.Should().Be(cell2.Id!.ToString());
    }

    [Fact]
    public async Task GetCells_ShouldReturnEmpty_WhenUserHasNoCells()
    {
        // Arrange
        var userId = "no_cells_user";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{userId}",
            Name = "No",
            LastName = "Cells",
            Email = "nocells@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        // Act
        var result = await Mediator.Send(new GetCellsQuery
        {
            Document = userId
        });

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}

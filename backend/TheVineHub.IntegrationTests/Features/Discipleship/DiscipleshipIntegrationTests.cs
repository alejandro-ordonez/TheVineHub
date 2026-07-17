using TheVineHub.API.Features.Discipleship.CreateNote;
using TheVineHub.API.Features.Discipleship.CreateNoteEntry;
using TheVineHub.API.Features.Discipleship.GetDiscipleshipNotes;
using TheVineHub.API.Features.Discipleship.GetDiscipleshipNoteById;
using TheVineHub.API.Features.Discipleship.GetNoteEntries;
using TheVineHub.API.Features.Discipleship;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users;
using TheVineHub.API.Features.Cells.UpsertCell;
using TheVineHub.API.Features.Cells.AddDisciples;
using Xunit;
using FluentAssertions;
using SurrealDb.Net.Models;

namespace TheVineHub.IntegrationTests.Features.Discipleship;

public class DiscipleshipIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task CreateNote_ShouldSuccessfullyCreateNote_WhenRequestorIsLeader()
    {
        // Arrange
        var leaderId = "discipleship_leader_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Leader",
            LastName = "Discipleship",
            Email = "leader_disc@example.com",
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
            Name = "Discipleship Cell",
            Description = "Test Cell",
            Address = "Address",
            MainCell = false
        });

        var discipleId = "disciple_disc_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Disciple",
            LastName = "Discipleship",
            Email = "disciple_disc@example.com",
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

        var command = new CreateNoteCommand
        {
            DiscipleId = discipleId,
            RequestorId = leaderId,
            Title = "First Mentoring Session",
            Description = "Initial session to establish goals.",
            Categories = new List<string> { "Spiritual Growth" }
        };

        // Act
        var result = await Mediator.Send(command);

        // Assert
        result.Should().NotBeNull();
        result.NoteId.Should().StartWith("journal_entry:");
        result.Title.Should().Be("First Mentoring Session");

        var notes = await Mediator.Send(new GetDiscipleshipNotesQuery
        {
            DiscipleId = discipleId,
            RequestorId = leaderId
        });

        notes.Should().Contain(n => n.NoteId == result.NoteId);
    }

    [Fact]
    public async Task CreateNoteEntry_ShouldSuccessfullyAddEntryToNote()
    {
        // Arrange
        var leaderId = "discipleship_leader_2";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Leader",
            LastName = "Discipleship 2",
            Email = "leader_disc2@example.com",
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
            Name = "Discipleship Cell 2",
            Description = "Test Cell",
            Address = "Address",
            MainCell = false
        });

        var discipleId = "disciple_disc_2";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Disciple",
            LastName = "Discipleship 2",
            Email = "disciple_disc2@example.com",
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

        var note = await Mediator.Send(new CreateNoteCommand
        {
            DiscipleId = discipleId,
            RequestorId = leaderId,
            Title = "Session with Entries",
            Description = "Test Note"
        });

        var command = new CreateNoteEntryCommand
        {
            NoteId = note.NoteId,
            DiscipleId = discipleId,
            RequestorId = leaderId,
            Content = "Follow-up observation: Disciple is doing well.",
            Date = DateTime.UtcNow
        };

        // Act
        var result = await Mediator.Send(command);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().StartWith("journal_entry:");
        result.Content.Should().Be("Follow-up observation: Disciple is doing well.");
    }

    [Fact]
    public async Task ManageNotesAndEntries_ShouldSuccessfullyQueryDetailsAndListEntries()
    {
        // Arrange
        var leaderId = "discipleship_leader_3";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{leaderId}",
            Name = "Leader",
            LastName = "Discipleship 3",
            Email = "leader_disc3@example.com",
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
            Name = "Discipleship Cell 3",
            Description = "Test Cell",
            Address = "Address",
            MainCell = false
        });

        var discipleId = "disciple_disc_3";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{discipleId}",
            Name = "Disciple",
            LastName = "Discipleship 3",
            Email = "disciple_disc3@example.com",
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

        // 1. Create a note
        var note = await Mediator.Send(new CreateNoteCommand
        {
            DiscipleId = discipleId,
            RequestorId = leaderId,
            Title = "Queryable Session",
            Description = "Test Queryable Description"
        });

        // 2. Query note by ID
        var noteDetails = await Mediator.Send(new GetDiscipleshipNoteByIdQuery
        {
            NoteId = note.NoteId,
            DiscipleId = discipleId,
            RequestorId = leaderId
        });

        noteDetails.Should().NotBeNull();
        noteDetails.NoteId.Should().Be(note.NoteId);
        noteDetails.Title.Should().Be("Queryable Session");
        noteDetails.Description.Should().Be("Test Queryable Description");

        // 3. Create note entry
        var entry = await Mediator.Send(new CreateNoteEntryCommand
        {
            NoteId = note.NoteId,
            DiscipleId = discipleId,
            RequestorId = leaderId,
            Content = "First test entry content",
            Date = DateTime.UtcNow
        });

        // 4. Query entries inside note
        var entries = await Mediator.Send(new GetNoteEntriesQuery
        {
            NoteId = note.NoteId,
            DiscipleId = discipleId,
            RequestorId = leaderId
        });

        entries.Should().NotBeEmpty();
        entries.Should().Contain(e => e.Id == entry.Id);
        entries.First(e => e.Id == entry.Id).Content.Should().Be("First test entry content");
    }
}

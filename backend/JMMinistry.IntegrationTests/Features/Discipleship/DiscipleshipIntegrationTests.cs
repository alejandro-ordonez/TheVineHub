using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNotes;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Enums;
using JMMinistry.Application.Features.Cells.Commands.CreateCell;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using Xunit;
using FluentAssertions;
using SurrealDb.Net.Models;

namespace JMMinistry.IntegrationTests.Features.Discipleship;

public class DiscipleshipIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task CreateNote_ShouldSuccessfullyCreateNote_WhenRequestorIsLeader()
    {
        // Arrange
        var leaderId = "discipleship_leader_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = RecordId.From("user", leaderId),
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
            Id = RecordId.From("user", discipleId),
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
            CellId = cell.Id!.DeserializeId<string>(),
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
            Id = RecordId.From("user", leaderId),
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
            Id = RecordId.From("user", discipleId),
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
            CellId = cell.Id!.DeserializeId<string>(),
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
}

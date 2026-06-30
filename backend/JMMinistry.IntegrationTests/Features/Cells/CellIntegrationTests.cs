using JMMinistry.Application.Features.Cells.Commands.CreateCell;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using JMMinistry.Application.Features.Cells.Queries.GetCells;
using JMMinistry.Application.Features.Cells.Queries.GetDisciples;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Enums;
using Xunit;
using FluentAssertions;
using SurrealDb.Net.Models;

namespace JMMinistry.IntegrationTests.Features.Cells;

public class CellIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task UpsertCell_ShouldSuccessfullyCreateCell()
    {
        // Arrange
        var leaderId = "cell_leader_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = RecordId.From("user", leaderId),
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
        result.Id?.Table.Should().Be("cell");
        result.Name.Should().Be("New Cell Group");
    }

    [Fact]
    public async Task AddDisciples_ShouldSuccessfullyAddDisciplesToCell()
    {
        // Arrange
        var leaderId = "cell_leader_2";
        await Mediator.Send(new CreateUserCommand
        {
            Id = RecordId.From("user", leaderId),
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
            Id = RecordId.From("user", discipleId),
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
            RequestorId = leaderId
        });

        disciples.Should().HaveCount(1);
    }
}

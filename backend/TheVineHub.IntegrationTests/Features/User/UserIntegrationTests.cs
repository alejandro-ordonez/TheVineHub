using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users.Authenticate;
using TheVineHub.API.Features.Users.GetUserInfo;
using TheVineHub.API.Features.Users.UpdateUser;
using TheVineHub.API.Features.Users.MarryLeaders;
using TheVineHub.API.Features.Users.CheckDocument;
using TheVineHub.API.Features.Users;
using Xunit;
using FluentAssertions;
using System.Security.Authentication;
using SurrealDb.Net.Models;

namespace TheVineHub.IntegrationTests.Features.User;

public class UserIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task CreateUser_ShouldSuccessfullyCreateUser()
    {
        // Arrange
        var command = new CreateUserCommand
        {
            Id = "user:test_user_1",
            Name = "Test",
            LastName = "User",
            Email = "test@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        };

        // Act
        var result = await Mediator.Send(command);

        // Assert
        result.Should().Be("User created successfully");

        var query = new GetUserInfoQuery("test_user_1", "test_user_1");
        var response = await Mediator.Send(query);

        response.Should().NotBeNull();
        response.User.FullName.Should().Be("Test User");
        response.User.Email.Should().Be("test@example.com");
    }

    [Fact]
    public async Task Authenticate_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var createCommand = new CreateUserCommand
        {
            Id = "user:auth_user_1",
            Name = "Auth",
            LastName = "User",
            Email = "auth@example.com",
            Password = "SecurePassword123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Married,
            City = "Bogotá",
            Neighborhood = "Auth Neighborhood",
            Address = "Auth Address"
        };
        await Mediator.Send(createCommand);

        var authCommand = new AuthenticateCommand("auth_user_1", "SecurePassword123!");

        // Act
        var result = await Mediator.Send(authCommand);

        // Assert
        result.Should().NotBeNull();
        result.IsAuthenticated.Should().BeTrue();
        result.Token.Should().NotBeNullOrEmpty();
        result.RefreshToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task Authenticate_ShouldThrowAuthenticationException_WhenPasswordIsInvalid()
    {
        // Arrange
        var createCommand = new CreateUserCommand
        {
            Id = "user:auth_user_2",
            Name = "Auth",
            LastName = "User",
            Email = "auth2@example.com",
            Password = "SecurePassword123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Married,
            City = "Bogotá",
            Neighborhood = "Auth Neighborhood",
            Address = "Auth Address"
        };
        await Mediator.Send(createCommand);

        var authCommand = new AuthenticateCommand("auth_user_2", "WrongPassword");

        // Act
        var act = async () => await Mediator.Send(authCommand);

        // Assert
        await act.Should().ThrowAsync<AuthenticationException>();
    }

    [Fact]
    public async Task UpdateUser_ShouldSuccessfullyModifyFields()
    {
        // Arrange
        var userId = "user:update_user_1";
        var createCommand = new CreateUserCommand
        {
            Id = userId,
            Name = "Original",
            LastName = "Name",
            Email = "original@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Original Neighborhood",
            Address = "Original Address"
        };
        await Mediator.Send(createCommand);

        var updateCommand = new UpdateUserCommand
        {
            Id = userId,
            Email = "updated@example.com",
            Phone = "0987654321",
            Birthday = new DateOnly(1990, 5, 15),
            MaritalStatus = MaritalStatus.Married,
            EducationalLevel = EducationalLevel.Bachelor,
            Profession = "Engineer",
            Occupation = "Developer",
            Address = "Updated Address",
            Neighborhood = "Updated Neighborhood",
            City = "Bogotá",
            Locality = "Suba",
            PhotoPath = "http://example.com/photo.png"
        };

        // Act
        var result = await Mediator.Send(updateCommand);

        // Assert
        result.Should().Be("User updated successfully");

        var query = new GetUserInfoQuery("update_user_1", "update_user_1");
        var response = await Mediator.Send(query);

        response.User.Email.Should().Be("updated@example.com");
        response.User.Address.Should().Be("Updated Address");
        response.User.MaritalStatus.Should().Be(MaritalStatus.Married);
    }

    [Fact]
    public async Task MarryLeaders_ShouldSuccessfullyRelateSpouses()
    {
        // Arrange
        var requestorId = "admin_user";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{requestorId}",
            Name = "Admin",
            LastName = "User",
            Email = "admin@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var spouse1Id = "spouse_leader_1";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{spouse1Id}",
            Name = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Male,
            MaritalStatus = MaritalStatus.Married,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var spouse2Id = "spouse_leader_2";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{spouse2Id}",
            Name = "Jane",
            LastName = "Doe",
            Email = "jane@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Married,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        var command = new MarryLeadersCommand
        {
            RequestorId = requestorId,
            PersonId = spouse1Id,
            SpouseId = spouse2Id
        };

        // Act
        await Mediator.Send(command);

        var spouse1 = RecordId.From("user", spouse1Id);
        var spouse2 = RecordId.From("user", spouse2Id);

        var spouse1Check = await DbSession.Query($"RETURN SELECT VALUE spouse FROM {spouse1};");
        var spouse1Value = spouse1Check.GetValue<List<RecordId>>(0)?.FirstOrDefault();
        spouse1Value.Should().Be(spouse2);

        var spouse2Check = await DbSession.Query($"RETURN SELECT VALUE spouse FROM {spouse2};");
        var spouse2Value = spouse2Check.GetValue<List<RecordId>>(0)?.FirstOrDefault();
        spouse2Value.Should().Be(spouse1);
    }

    [Fact]
    public async Task CheckDocumentExists_ShouldReturnCorrectResult()
    {
        // Arrange
        var document = "document_to_check";
        await Mediator.Send(new CreateUserCommand
        {
            Id = $"user:{document}",
            Name = "Check",
            LastName = "Me",
            Email = "check@example.com",
            Password = "Password123!",
            Phone = "1234567890",
            Gender = Gender.Female,
            MaritalStatus = MaritalStatus.Single,
            City = "Bogotá",
            Neighborhood = "Test Neighborhood",
            Address = "Test Address"
        });

        // Act & Assert
        var checkExisting = await Mediator.Send(new CheckDocumentExistsQuery { Document = document });
        checkExisting.Should().NotBeNull();
        checkExisting.Exists.Should().BeTrue();
        checkExisting.Name.Should().Be("Check");
        checkExisting.LastName.Should().Be("Me");

        var checkMissing = await Mediator.Send(new CheckDocumentExistsQuery { Document = "non_existent_document" });
        checkMissing.Should().NotBeNull();
        checkMissing.Exists.Should().BeFalse();
        checkMissing.Name.Should().BeNullOrEmpty();
        checkMissing.LastName.Should().BeNullOrEmpty();
    }
}

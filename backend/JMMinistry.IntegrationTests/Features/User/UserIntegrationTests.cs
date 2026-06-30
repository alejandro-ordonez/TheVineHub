using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Queries.GetUserInfo;
using JMMinistry.Application.Features.User.Enums;
using JMMinistry.Application.Features.User.Dtos;
using Xunit;
using FluentAssertions;
using System.Security.Authentication;
using SurrealDb.Net.Models;

namespace JMMinistry.IntegrationTests.Features.User;

public class UserIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task CreateUser_ShouldSuccessfullyCreateUser()
    {
        // Arrange
        var command = new CreateUserCommand
        {
            Id = RecordId.From("user", "test_user_1"),
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

        var query = new GetUserInfoQuery
        {
            Document = "test_user_1",
            RequestorDocument = "test_user_1"
        };
        var user = await Mediator.Send(query);

        user.Should().NotBeNull();
        user.FullName.Should().Be("Test User");
        user.Email.Should().Be("test@example.com");
    }

    [Fact]
    public async Task Authenticate_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var createCommand = new CreateUserCommand
        {
            Id = RecordId.From("user", "auth_user_1"),
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

        var authCommand = new AuthenticateCommand
        {
            Document = "auth_user_1",
            Password = "SecurePassword123!"
        };

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
            Id = RecordId.From("user", "auth_user_2"),
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

        var authCommand = new AuthenticateCommand
        {
            Document = "auth_user_2",
            Password = "WrongPassword"
        };

        // Act
        var act = async () => await Mediator.Send(authCommand);

        // Assert
        await act.Should().ThrowAsync<AuthenticationException>();
    }
}

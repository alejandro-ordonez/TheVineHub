using JMMinistry.Application.Features.Location.GetLocationData;
using Xunit;
using FluentAssertions;

namespace JMMinistry.IntegrationTests.Features.Location;

public class LocationIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task GetLocationData_ShouldReturnSeededCitiesAndLocalities()
    {
        // Act
        var result = await Mediator.Send(new GetLocationDataQuery());

        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();

        var bogota = result.FirstOrDefault(c => c.Name == "Bogotá");
        bogota.Should().NotBeNull();
        bogota!.Localities.Should().NotBeEmpty();
        bogota.Localities.Select(l => l.Name).Should().Contain(new[] { "Fontibón", "Bosa", "Suba" });
    }
}

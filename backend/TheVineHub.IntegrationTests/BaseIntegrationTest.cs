using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SurrealDb.Net;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Moq;
using TheVineHub.API.Configuration;
using TheVineHub.API.Infrastructure.Database;
using TheVineHub.API.Infrastructure.Storage;
using Mediator;
using Xunit;

namespace TheVineHub.IntegrationTests;

public abstract class BaseIntegrationTest : IAsyncLifetime
{
    private readonly IContainer _surrealDbContainer = new ContainerBuilder()
        .WithImage("surrealdb/surrealdb:1.0.0")
        .WithCommand("start", "--user", "root", "--pass", "root", "--bind", "0.0.0.0:8000")
        .WithPortBinding(8000, true)
        .WithWaitStrategy(Wait.ForUnixContainer().UntilMessageIsLogged(".*Started.*"))
        .Build();

    protected IServiceProvider ServiceProvider { get; private set; } = null!;
    protected IMediator Mediator => ServiceProvider.GetRequiredService<IMediator>();
    protected ISurrealDbSession DbSession => ServiceProvider.GetRequiredService<ISurrealDbSession>();

    public async Task InitializeAsync()
    {
        await _surrealDbContainer.StartAsync();

        var host = _surrealDbContainer.Hostname;
        var port = _surrealDbContainer.GetMappedPublicPort(8000);
        var connectionString = $"Server=http://{host}:{port};Namespace=test;Database=test;Username=root;Password=root";

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:SurrealDb"] = connectionString,
                ["JwtSettings:Key"] = "SuperSecretKeyThatIsLongEnoughForHmacSha256",
                ["JwtSettings:Issuer"] = "TheVineHub",
                ["JwtSettings:Audience"] = "TheVineHub",
                ["JwtSettings:DurationInMinutes"] = "60"
            })
            .Build();

        var services = new ServiceCollection();

        // Add required services that would normally be added by the host
        services.AddSingleton<IConfiguration>(configuration);
        services.AddLogging();

        // Add layers from TheVineHub.API
        services.AddApplicationServices(configuration);
        services.AddPersistenceLayer(configuration);

        // Mock IPhotoService to avoid MinIO dependency
        var photoServiceMock = new Mock<IPhotoService>();
        services.AddSingleton(photoServiceMock.Object);

        ServiceProvider = services.BuildServiceProvider();

        // Apply migrations
        await ServiceProvider.ApplyMigrationsAsync();
    }

    public async Task DisposeAsync()
    {
        await _surrealDbContainer.StopAsync();
    }
}

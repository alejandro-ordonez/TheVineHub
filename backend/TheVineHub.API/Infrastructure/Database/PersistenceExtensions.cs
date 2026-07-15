using TheVineHub.API.Infrastructure.Storage;
using TheVineHub.API.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurrealDb.Net;

namespace TheVineHub.API.Infrastructure.Database
{
    public static class PersistenceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSurreal(configuration.GetConnectionString("SurrealDb") ?? throw new ArgumentException("Connection string not set"));

            services.AddScoped<IPhotoService, MinioPhotoService>();
            services.AddScoped<IDbMigrationService, DbMigrationService>();

            services.Configure<DefaultUser>(configuration.GetSection(nameof(DefaultUser)));
        }

        public static async Task ApplyMigrationsAsync(this IServiceProvider serviceProvider)
        {
            await using var scope = serviceProvider.CreateAsyncScope();
            var migrationService = scope.ServiceProvider.GetRequiredService<IDbMigrationService>();
            await migrationService.MigrateAsync();
        }
    }
}

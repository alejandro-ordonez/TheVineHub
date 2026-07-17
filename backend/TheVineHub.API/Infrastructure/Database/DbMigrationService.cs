using System.Reflection;
using System.IO;
using SurrealDb.Net;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using SurrealDb.Net.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheVineHub.API.Infrastructure.Database;

[Table("migration")]
public class Migration : Record
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("applied_at")]
    public DateTime AppliedAt { get; set; } = DateTime.Now;
}

public interface IDbMigrationService
{
    Task MigrateAsync();
}

public class DbMigrationService : IDbMigrationService
{
    private readonly ISurrealDbSession _session;
    private readonly ILogger<DbMigrationService> _logger;

    public DbMigrationService(ISurrealDbSession session, ILogger<DbMigrationService> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task MigrateAsync()
    {
        _logger.LogInformation("Starting database migrations...");

        try
        {
            // 1. Ensure migration table exists
            await _session.RawQuery($"""
                DEFINE TABLE IF NOT EXISTS migration SCHEMAFULL;
                DEFINE FIELD name ON migration TYPE string;
                DEFINE FIELD applied_at ON migration TYPE datetime DEFAULT time::now();
                DEFINE INDEX idx_name ON migration FIELDS name UNIQUE;
                """);

            // 2. Get applied migrations using the correct fluent API and attributes
            var appliedMigrations = await _session.Select<Migration>("migration") ?? [];
            var appliedNames = appliedMigrations.Select(m => m.Name).ToHashSet();

            // 3. Get embedded migrations
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames()
                .Where(r => r.EndsWith(".surql"))
                .OrderBy(r => r)
                .ToList();

            foreach (var resourceName in resourceNames)
            {
                // Resource name format: TheVineHub.API.Infrastructure.Database.Migrations.0001_core_tables.surql
                var parts = resourceName.Split('.');
                if (parts.Length < 2) continue;

                var name = parts[parts.Length - 2];

                if (appliedNames.Contains(name))
                {
                    _logger.LogInformation("Migration {MigrationName} already applied.", name);
                    continue;
                }

                _logger.LogInformation("Applying migration {MigrationName}...", name);

                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    _logger.LogWarning("Could not find resource stream for {ResourceName}", resourceName);
                    continue;
                }

                using var reader = new StreamReader(stream);
                var script = await reader.ReadToEndAsync();

                // Wrap in transaction to ensure all statements are applied or none
                var transactionScript = $"""
                    BEGIN;
                    {script}
                    COMMIT;
                    """;

                try
                {
                    var migrationResponse = await _session.RawQuery(transactionScript);
                    if (migrationResponse.HasErrors)
                    {
                        var errors = string.Join(", ", migrationResponse.Errors.Select(e => e.ToString()));
                        _logger.LogError("Error applying migration {MigrationName}: {Errors}", name, errors);
                        throw new Exception($"Migration {name} failed: {errors}");
                    }
                }
                catch (SurrealDb.Net.Exceptions.Rpc.SurrealDbValidationException valEx)
                {
                    _logger.LogError(valEx, "Validation error in migration {MigrationName}. Message: {Message}", name, valEx.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error while applying migration {MigrationName}", name);
                    throw;
                }

                // Use .Create with the mapped object
                await _session.Create("migration", new Migration { Name = name });

                _logger.LogInformation("Migration {MigrationName} applied successfully.", name);
            }

            _logger.LogInformation("Database migrations completed successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during database migration.");
            throw;
        }
    }
}

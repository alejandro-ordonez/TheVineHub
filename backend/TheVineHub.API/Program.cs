using dotenv.net;
using TheVineHub.API.Configuration;
using TheVineHub.API.Features;
using TheVineHub.API.Infrastructure.Database;
using Microsoft.Extensions.FileProviders;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
DotEnv.Load(options: new DotEnvOptions(probeForEnv: true, probeLevelsToSearch: 4));
builder.Configuration.AddEnvironmentVariables();

builder.AddOpenTelemetryConfiguration();

const string CorsPolicy = "_corsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy, policy =>
    {
        policy.SetIsOriginAllowed(origin =>
                origin == "https://app.thevinehub.org" || new Uri(origin).Host == "localhost"
             )
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// ─── Services ────────────────────────────────────────────────────────────────

builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

// Scan and register all IEndpoint implementations
builder.Services.AddEndpoints();

builder.Services.AddOpenApi();

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy(CacheTags.DiscipleSteps, policy =>
    {
        policy.AddPolicy<AuthenticatedOutputCachePolicy>();
        policy.Expire(TimeSpan.FromHours(24));
        policy.Tag(CacheTags.DiscipleSteps);
    });

    options.AddPolicy(CacheTags.StepCycles, policy =>
    {
        policy.AddPolicy<AuthenticatedOutputCachePolicy>();
        policy.Expire(TimeSpan.FromHours(1));
        policy.Tag(CacheTags.StepCycles);
    });

    options.AddPolicy(CacheTags.CycleData, policy =>
    {
        policy.AddPolicy<AuthenticatedOutputCachePolicy>();
        policy.Expire(TimeSpan.FromHours(1));
        policy.Tag(CacheTags.CycleData);
    });

    options.AddPolicy(CacheTags.Meetings, policy =>
    {
        policy.AddPolicy<AuthenticatedOutputCachePolicy>();
        policy.Expire(TimeSpan.FromHours(1));
        policy.Tag(CacheTags.Meetings);
    });
});

// ─── Build ────────────────────────────────────────────────────────────────────

var app = builder.Build();

await app.Services.ApplyMigrationsAsync();

app.UseExceptionHandler();

// ─── HTTP Pipeline ────────────────────────────────────────────────────────────

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Authentication = new Scalar.AspNetCore.ScalarAuthenticationOptions
        {
            PreferredSecurityScheme = "BearerAuth"
        };
    });
}

app.UseCors(CorsPolicy);

var uploadsPath = builder.Configuration.GetValue<string>("UploadsPath")
    ?? Path.Combine(Directory.GetCurrentDirectory(), "uploads");
Directory.CreateDirectory(uploadsPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});

app.UseAuthentication();
app.UseAuthorization();
app.UseOutputCache();

// Map all vertical slice endpoints automatically
app.MapEndpoints();

await app.RunAsync();

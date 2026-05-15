using JMMinistry.API.Extensions;
using JMMinistry.API.Middleware;
using JMMinistry.Application;
using JMMinistry.Infrastructure.Persistence;
using Microsoft.Extensions.FileProviders;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddOpenTelemetryConfiguration();

var CORSPolicy = "_corsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORSPolicy,
                      policy =>
                      {
                          policy.SetIsOriginAllowed(origin =>
                                origin == "https://app.jm-ministry.org" || new Uri(origin).Host == "localhost"
                             )
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);

builder.Services.AddOpenApi();

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy(CacheTags.DiscipleSteps, builder =>
    {
        builder.AddPolicy<AuthenticatedOutputCachePolicy>();
        builder.Expire(TimeSpan.FromHours(24));
        builder.Tag(CacheTags.DiscipleSteps);
    });

    options.AddPolicy(CacheTags.StepCycles, builder =>
    {
        builder.AddPolicy<AuthenticatedOutputCachePolicy>();
        builder.Expire(TimeSpan.FromHours(1));
        builder.Tag(CacheTags.StepCycles);
    });

    options.AddPolicy(CacheTags.CycleData, builder =>
    {
        builder.AddPolicy<AuthenticatedOutputCachePolicy>();
        builder.Expire(TimeSpan.FromHours(1));
        builder.Tag(CacheTags.CycleData);
    });

    options.AddPolicy(CacheTags.Meetings, builder =>
    {
        builder.AddPolicy<AuthenticatedOutputCachePolicy>();
        builder.Expire(TimeSpan.FromHours(1));
        builder.Tag(CacheTags.Meetings);
    });
});

var app = builder.Build();

await app.Services.ApplyMigrationsAsync();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => options
    .AddPreferredSecuritySchemes("BearerAuth")
    .AddHttpAuthentication("BearerAuth", auth =>
    {
        auth.Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";
    }));
}

app.UseCors(CORSPolicy);

var uploadsPath = builder.Configuration.GetValue<string>("UploadsPath")
    ?? Path.Combine(Directory.GetCurrentDirectory(), "uploads");
Directory.CreateDirectory(uploadsPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.UseResponseMiddleware();
});

app.UseAuthentication();
app.UseAuthorization();

app.UseOutputCache();

app.MapControllers();

await app.RunAsync();

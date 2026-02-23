using JMMinistry.API.Extensions;
using JMMinistry.API.Middleware;
using JMMinistry.Application;
using JMMinistry.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

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

builder.Services.AddOutputCache();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseExceptionHandler();

app.MapDefaultEndpoints();

await app.InitializeDb();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseCors(CORSPolicy);

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.UseResponseMiddleware();
});


app.UseSwagger();
app.UseSwaggerUI();

app.UseOutputCache();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

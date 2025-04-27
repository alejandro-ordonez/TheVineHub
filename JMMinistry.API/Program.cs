using JMMinistry.API.Extensions;
using JMMinistry.API.Middleware;
using JMMinistry.Application;
using JMMinistry.Application.Exceptions;
using JMMinistry.Infrastructure.Persistence;
using LettuceEncrypt;
using Microsoft.OpenApi.Models;

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

builder.Services.AddSwagger();

var app = builder.Build();

app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.InitializeDb();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.UseResponseMiddleware();
});


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(CORSPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

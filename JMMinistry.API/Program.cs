using JMMinistry.API.Middleware;
using JMMinistry.Application;
using JMMinistry.Infrastructure.Persistence;
using LettuceEncrypt;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var CORSPolicy = "_corsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORSPolicy,
                      policy =>
                      {
                          policy.WithOrigins("https://app.jm-ministry.org", "http://localhost:5048")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler();
app.InitializeDb();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseResponseMiddleware();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(CORSPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

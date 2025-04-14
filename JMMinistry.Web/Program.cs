using Blazored.LocalStorage;
using Fluxor;
using JMMinistry.Web;
using JMMinistry.Web.Api;
using JMMinistry.Web.Extensions;
using JMMinistry.Web.Services;
using JMMinistry.Web.Store;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluxor(options => options
    .ScanAssemblies(typeof(Program).Assembly)
    .AddMiddleware<FailedActionMiddleware>());

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();
builder.Services.AddServices();
builder.Services.AddMudServices();
builder.Services.AddApiServices();

var host = builder.Build();

await host.SetDefaultUICulture();

await host.RunAsync();

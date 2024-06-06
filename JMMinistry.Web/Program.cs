using Blazored.LocalStorage;
using JMMinistry.Web;
using JMMinistry.Web.Api;
using JMMinistry.Web.Extensions;
using JMMinistry.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();
builder.Services.AddApiServices();
builder.Services.AddServices();

var host = builder.Build();

await host.SetDefaultUICulture();

await host.RunAsync();

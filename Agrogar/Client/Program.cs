global using Agrogar.Shared;
global using Agrogar.Shared.DTOs;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components.Authorization;
global using System.Security.Claims;
global using Agrogar.Client.Services.AuthService;
global using Agrogar.Client.Services.AssignmentService;
global using Agrogar.Client.Services.DataService;
global using Agrogar.Client.Services.PropertyService;
global using Agrogar.Client.Services.WorkService;
global using Agrogar.Client.Services.DataStorageService;
global using Agrogar.Client.Services.CadasterService;
using Agrogar.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddSingleton<IDataStorageService, DataStorageService>();
builder.Services.AddScoped<ICadasterService, CadasterService>();
builder.Services.AddMudServices(config =>
{
	config.SnackbarConfiguration.VisibleStateDuration = 4000;
});



builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();

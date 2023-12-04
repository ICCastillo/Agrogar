global using Agrogar.Shared;
global using Microsoft.EntityFrameworkCore;
global using Agrogar.Server.Services.AuthService;
global using Agrogar.Server.Services.PropertyService;
global using Agrogar.Server.Services.CategoryService;
global using Agrogar.Server.Services.WorkService;
global using Agrogar.Server.Services.AssignmentService;
global using Agrogar.Server.Services.JobPositionService;
global using Agrogar.Server.Services.WorkPhaseService;
global using Agrogar.Server.Services.TaskTypeService;
global using Agrogar.Server.Services.PropertyBuilderService;
global using Agrogar.Server.Data;
global using Agrogar.Server.Services.WorkBuilderService;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IJobTitleService, JobTitleService>();
builder.Services.AddScoped<IWorkPhaseService, WorkPhaseService>();
builder.Services.AddScoped<ITaskTypeService, TaskTypeService>();
builder.Services.AddScoped<IPropertyAssemblyService, PropertyAssemblyService>();
builder.Services.AddScoped<IWorkAssemblyService, WorkAssemblyService>();


var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

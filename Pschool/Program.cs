//using Pschool.Client.Pages;
using Pschool.Components;
using PschoolCrud.Services.Interfaces;
using PschoolCrud.Services;
using Microsoft.EntityFrameworkCore;
using PschoolCrud.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri("https://localhost:7175")
});

builder.Services.AddDbContext<PschoolContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 23))));

builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IStudentService, StudentService>();
  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
	.AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Pschool.Client._Imports).Assembly);

app.Run();

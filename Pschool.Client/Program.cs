using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PschoolCrud.Services;
using PschoolCrud.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri("https://localhost:7175")
});

builder.Services.AddScoped<IParentService, ClientParentService>();
builder.Services.AddScoped<IStudentService, ClientStudentService>();

await builder.Build().RunAsync();

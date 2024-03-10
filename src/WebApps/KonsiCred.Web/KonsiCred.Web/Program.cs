using KonsiCred.Web;
using KonsiCred.Web.Client.Pages;
using KonsiCred.Web.Components;
using Microsoft.FluentUI.AspNetCore.Components;

using IHost host = Host.CreateApplicationBuilder(args).Build();

IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Configuration
                    .SetBasePath(builder.Environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();

builder.Services.AddFluentUIComponents();

builder.Services.AddScoped<IDadosClienteService, DadosClienteService>();
builder.Services.AddHttpClient(KonsiCredOptions.Instance, options =>
{
});
builder.Services.Configure<KonsiCredOptions>(config.GetSection(nameof(KonsiCredOptions)));

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
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
.AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();

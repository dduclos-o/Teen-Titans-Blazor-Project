using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TeenTitansApp.Data;
using TeenTitansRP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<PowerService>();
builder.Services.AddHttpClient();

// Register your CharacterService and configure HttpClient
builder.Services.AddHttpClient<CharacterService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7117/");
});

// Register your TeamService and configure HttpClient
builder.Services.AddHttpClient<TeamService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7117/");
});

// Register your PowerService and configure HttpClient
builder.Services.AddHttpClient<PowerService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7117/");
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

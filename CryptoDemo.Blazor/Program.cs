using CryptoDemo.Blazor.Models;
using CryptoDemo.Services;
using CryptoDemo.Services.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddLogging(config => config.AddConsole());

builder.Services.Configure<CoinApiOptions>(builder.Configuration.GetSection("CoinApiOptions"));
builder.Services.AddSingleton<CoinApiClient>();

builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

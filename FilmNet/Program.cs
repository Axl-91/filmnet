using DotNetEnv;
using FilmNet.Data;
using FilmNet.Data.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Build connection string from environment variables
var server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost,1433";
var database = Environment.GetEnvironmentVariable("DB_NAME") ?? "DefaultDb";
var password = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? "";

var connectionString = $"Server={server};Database={database};User Id=sa;Password={password};TrustServerCertificate=true;";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FilmDbContext>(options =>
    options.UseSqlServer(connectionString)
    );
builder.Services.AddScoped<IFilmsService,  FilmsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
using CityInfoServiceAPI;
using CityInfoServiceAPI.DbContexts;
using CityInfoServiceAPI.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

// Configuring Serilog Logger Profile
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityInfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// builder.Logging.ClearProviders();
// builder.Logging.AddConsole();
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers(options =>
    {
        // Not Acceptable HTTP Headers
        options.ReturnHttpNotAcceptable = true;
    }).AddNewtonsoftJson()
    .AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

// Adding Mail Service
// Using Compiler Directives
#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();

#else
builder.Services.AddTransient<IMailService, CloudMailService>();

#endif

// Registering _CitiesDataStore in services container
builder.Services.AddSingleton<CitiesDataStore>();

// Register for Dependency Injection
builder.Services.AddDbContext<CityInfoContext>(dbContextOptions =>
    dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
// Generates UI Documentation
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endPoints => { endPoints.MapControllers(); }
);

app.MapControllers();

app.Run();
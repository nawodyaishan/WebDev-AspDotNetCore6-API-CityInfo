using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    // Not Acceptable HTTP Headers
    options.ReturnHttpNotAcceptable = true;
}).AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// // Configure the HTTP request pipeline.

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
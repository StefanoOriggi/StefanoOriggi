using cinema.Data;
using cinema.EndPoints;
using cinema.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("connString");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<CinemaContext>(dbcontextOptions =>
                    dbcontextOptions.UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    );

builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "cinemaAPI";
    config.Title = "cinema v1";
    config.Version = "v1";
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "cinemaAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapAttoriEndPoints();
app.Run();

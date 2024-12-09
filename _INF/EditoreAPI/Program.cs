using EditoreAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("libreriaConn");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<LibreriaContext>(options => options
    .UseMySql(connectionString, serverVersion)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Editore API";
});
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();

using FilmAPI.Data;
using FilmAPI.Endpoints;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
	{
		config.Title = "FilmAPI";
		config.DocumentName = "Film API";
		config.Version = "v1";
	}
);
if (builder.Environment.IsDevelopment())
{
	builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}

var connectionString = builder.Configuration.GetConnectionString("FilmAPIConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);
//Aggiungiamo il servizio database tramite EF Core con MariaDB
builder.Services.AddDbContext<FilmDbContext>(
	opt => opt.UseMySql(connectionString, serverVersion)
	.LogTo(Console.WriteLine, LogLevel.Information)
	.EnableSensitiveDataLogging()
	.EnableDetailedErrors()
	);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
	app.UseOpenApi();
	//permette di configurare l'interfaccia SwaggerUI (l'interfaccia grafica web di Swagger (NSwag) che permette di interagire con le API)
	app.UseSwaggerUi(config =>
	{
		config.DocumentTitle = "Film API";
		config.Path = "/swagger";
		config.DocumentPath = "/swagger/{documentName}/swagger.json";
		config.DocExpansion = "list";
	});
}

app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapGroup("/api")
.MapRegistaEndpoints()
.MapFilmEndpoints()
.MapProiezioniEndpoints()
.MapCinemaEndpoints()
.WithOpenApi()
.WithTags("Public API");

app.Run();

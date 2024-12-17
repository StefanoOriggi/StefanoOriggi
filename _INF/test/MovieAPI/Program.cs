using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using MovieAPI.ModelsDTO;
using MovieAPI.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FilmConn");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<FilmContext>(dbcontextOptions =>
                    dbcontextOptions.UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    );

builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "FilmApi";
    config.Title = "Film v1";
    config.Version = "v1";
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "FilmApi";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}
#region registiEndPoints
app.MapGet("/registi", async (FilmContext db) =>
{
    return Results.Ok(await db.Regista.Select(r => new RegistaDTO(r)).ToListAsync());
});
app.MapGet("/registi/{Id}", async (FilmContext db, int Id) =>
{
    var regista = await db.Regista.FindAsync(Id);
    if (regista is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(regista);

});

app.MapPost("/registi", async (FilmContext db, RegistaDTO registaDTO) =>
{
    Regista regista = new()
    {
        Nome = registaDTO.Nome,
        Cognome = registaDTO.Cognome,
        Nazionalita = registaDTO.Nazionalita,
    };
    await db.Regista.AddAsync(regista);
    await db.SaveChangesAsync();
    return Results.Created("/registi/regista.RegistaId", new RegistaDTO(regista));
});
app.MapPut("/registi/{id}", async (FilmContext db, RegistaDTO registaDTO, int id) =>
{
    var regista = await db.Regista.FindAsync(id);
    if (regista is null){
        return Results.NotFound();
    }
    regista.Nome = registaDTO.Nome;
    regista.Cognome = registaDTO.Cognome;
    regista.Nazionalita = registaDTO.Nazionalita;
    await db.SaveChangesAsync();
    return Results.Ok(regista);
});
app.MapDelete("/registi/{id}", async (FilmContext db, int id) =>
{
    var regista = await db.Regista.FindAsync(id);
    if(regista is null)
        return Results.NotFound();
    db.Remove(regista);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion

#region attoriEndPoints
app.MapGet("/attori", async (FilmContext db) =>
{
    return Results.Ok(await db.Attore.Select(r => new AttoreDTO(r)).ToListAsync());
});
app.MapGet("/attori/{Id}", async (FilmContext db, int Id) =>
{
    var attore = await db.Attore.FindAsync(Id);
    if (attore is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(attore);

});

app.MapPost("/attore", async (FilmContext db, AttoreDTO attoreDTO) =>
{
    Attore attore= new()
    {
        Nome = attoreDTO.Nome,
        Cognome = attoreDTO.Cognome,
        Eta = attoreDTO.Eta,
    };
    await db.Attore.AddAsync(attore);
    await db.SaveChangesAsync();
    return Results.Created("/registi/regista.RegistaId", new AttoreDTO(attore));
});
app.MapPut("/attori/{id}", async (FilmContext db, AttoreDTO attoreDTO, int id) =>
{
    var attore = await db.Attore.FindAsync(id);
    if (attore is null)
    {
        return Results.NotFound();
    }
    attore.Nome = attoreDTO.Nome;
    attore.Cognome = attoreDTO.Cognome;
    attore.Eta = attoreDTO.Eta;
    await db.SaveChangesAsync();
    return Results.Ok(attore);
});
app.MapDelete("/attori/{id}", async (FilmContext db, int id) =>
{
    var attore = await db.Attore.FindAsync(id);
    if (attore is null)
        return Results.NotFound();
    db.Remove(attore);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion

#region filmEndPoints
app.MapGet("/film", async (FilmContext db) =>
{
    return Results.Ok(await db.Film.Select(r => new FilmDTO(r)).ToListAsync());
});
app.MapGet("/film/{Id}", async (FilmContext db, int Id) =>
{
    var film = await db.Film.FindAsync(Id);
    if (film is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(film);

});
app.MapPost("/film", async (FilmContext db, FilmDTO filmDTO) =>
{
    Film film = new()
    {
        Titolo = filmDTO.Titolo,
        Datauscita = filmDTO.Datauscita,
        Genere = filmDTO.Genere,
        RegistaId = filmDTO.RegistaId
    };
    await db.Film.AddAsync(film);
    await db.SaveChangesAsync();
    return Results.Created("/film/film.FilmId", new FilmDTO(film));
});
app.MapPut("/film/{id}", async (FilmContext db, FilmDTO filmDTO, int id) =>
{
    var film = await db.Film.FindAsync(id);
    if (film is null)
    {
        return Results.NotFound();
    }
    film.Titolo = filmDTO.Titolo;
    film.Datauscita = filmDTO.Datauscita;
    film.Genere = filmDTO.Genere;
    film.RegistaId = filmDTO.RegistaId;
    await db.SaveChangesAsync();
    return Results.Ok(film);
});
app.MapDelete("/film/{id}", async (FilmContext db, int id) =>
{
    var film = await db.Film.FindAsync(id);
    if (film is null)
        return Results.NotFound();
    db.Remove(film);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion

#region altri_endpoints
//GET /attori/{id}/film: Recupera tutti i film di un attore specifico
app.MapGet("/attori/{id}/film", async (FilmContext db, int id) =>
{
    var attore = await db.Attore.FindAsync(id);
    if (attore is null)
    {
        return Results.NotFound();
    }
    var films = await db.Film.Where(f => f.filmAttori.Any(a => a.AttoreId == id)).ToListAsync();
    return Results.Ok(films.Select(f => new FilmDTO(f)));
});

//POST /attori/{id}/film: Aggiunge un film ad un attore
app.MapPost("/attori/{id}/film", async (FilmContext db, int id, FilmDTO filmDTO) =>
{
    var attore = await db.Attore.FindAsync(id);
    if (attore is null)
    {
        return Results.NotFound();
    }
    var film = new Film
    {
        Titolo = filmDTO.Titolo,
        Datauscita = filmDTO.Datauscita,
        Genere = filmDTO.Genere,
        RegistaId = filmDTO.RegistaId
    };
    await db.Film.AddAsync(film);
    await db.SaveChangesAsync();
    return Results.Created($"/film/{film.FilmId}", new FilmDTO(film));
});
//DELETE /attori/{id}/film: Elimina tutti i film a cui ha partecipato un attore.
app.MapDelete("/attori/{id}/film", async (FilmContext db, int id) =>
{
    var attore = await db.Attore.FindAsync(id);
    if (attore is null)
    {
        return Results.NotFound();
    }
    var films = await db.Film.Where(f => f.filmAttori.Any(a => a.AttoreId == id)).ToListAsync();
    if (films.Count == 0)
    {
        return Results.NotFound();
    }
    db.RemoveRange(films);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion
app.Run();

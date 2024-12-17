using LibreriaApi.ModelsDTO;
using LibreriaApi.Models;
using LibreriaApi.Data;
using Microsoft.EntityFrameworkCore;
namespace LibreriaApi.EndPoints;
public static class LibroEndPoints
{
    public static void MapLibriEndPoints(this WebApplication app)
    {
        app.MapPost("/libri", async (LibreriaContext db, LibroDTO libroDTO) =>
        {
            var libro = new Libro
            {
                Titolo = libroDTO.Titolo,
                Prezzo = libroDTO.Prezzo,
                NumeroPagine = libroDTO.NumeroPagine,
                EditoreId = libroDTO.EditoreId,
            };
            db.Libri.Add(libro);
            await db.SaveChangesAsync();
            return Results.Created($"/libri/{libro.LibroId}", libro);
        });
        app.MapGet("/libri", async (LibreriaContext db) =>
        {
            return Results.Ok(await db.Libri.ToListAsync());
        });
        app.MapGet("/libri1/{libriId}", async (LibreriaContext db, int id) =>
        {
            var libro = await db.Libri.FindAsync(id);
            if (libro is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(libro);
        });
        app.MapPut("/libri/{libriId}", async (LibreriaContext db, int id, LibroDTO libroDTO) =>
        {
            var libro = await db.Libri.FindAsync(id);
            if (libro is null)
            {
                return Results.NotFound();
            }
            libro.Titolo = libroDTO.Titolo;
            libro.Prezzo = libroDTO.Prezzo; 
            libro.NumeroPagine = libroDTO.NumeroPagine;
            libro.EditoreId = libroDTO.EditoreId;
            await db.SaveChangesAsync();
            return Results.Ok(libro);
        });
        app.MapDelete("/libri/{libriId}", async (LibreriaContext db, int id) =>
        {
            var libro = await db.Libri.FindAsync(id);
            if (libro is null)
            {
                return Results.NotFound();
            }
            db.Libri.Remove(libro);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
        app.MapGet("/editori/{editoreId}/libri", async (LibreriaContext db, int editoreId) =>
        {
            var libri = await db.Libri.Where(l => l.EditoreId == editoreId).ToListAsync();
            if (libri is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(libri);
        });
        app.MapPost("/editori/{editoreId}/libri", async (LibreriaContext db, int id, LibroDTO libroDTO) =>
        {
            var libro = new Libro
            {
                Titolo = libroDTO.Titolo,
                Prezzo = libroDTO.Prezzo,
                NumeroPagine = libroDTO.NumeroPagine,
                EditoreId = id
            };
            db.Libri.Add(libro);
            await db.SaveChangesAsync();
            return Results.Created($"/libri/{libro.LibroId}", libro);
        });
        app.MapPut("/editori/{editoreId}/libri/{libriId}", async (LibreriaContext db, int id, int libroId, LibroDTO libroDTO) =>
        {
            var libro = await db.Libri.FindAsync(libroId);
            if (libro is null)
            {
                return Results.NotFound();
            }
            libro.Titolo = libroDTO.Titolo;
            libro.Prezzo = libroDTO.Prezzo;
            libro.NumeroPagine = libroDTO.NumeroPagine;
            await db.SaveChangesAsync();
            return Results.Ok(libro);
        });
        app.MapDelete("/editori/{editoreId}/libri", async (LibreriaContext db, int id) =>
        {
            var libri = await db.Libri.Where(l => l.EditoreId == id).ToListAsync();
            if (libri is null)
            {
                return Results.NotFound();
            }
            db.Libri.RemoveRange(libri);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

    }
}

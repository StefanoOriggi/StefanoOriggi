using LibreriaApi.Models;
using LibreriaApi.ModelsDTO;
using LibreriaApi.Data;
using Microsoft.EntityFrameworkCore; 
namespace LibreriaApi.EndPoints;
public static class EditoreEndPoints
{
    public static void MapEditoreEndPoints(this WebApplication app)
    {
        app.MapPost("/api/editore", async (LibreriaContext db, EditoreDTO editoreDTO) =>
        {
            var editore = new Editore
            {
                NomeEditore = editoreDTO.NomeEditore,
                Città = editoreDTO.Citta
            };
            db.Editori.Add(editore);
            await db.SaveChangesAsync();
            return editore;
        });
        app.MapGet("/api/editore", async (LibreriaContext db) =>
        {
            return Results.Ok(await db.Editori.ToListAsync());
        });
        //ottieni un autore
        app.MapGet("/api/editore/{id}", async (LibreriaContext db, int id) =>
        {
            var editore = await db.Editori.FindAsync(id);
            if (editore is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(editore);
        });
        //aggiorna un autore 
        app.MapPut("/api/editore/{id}", async (LibreriaContext db, int id, EditoreDTO editoreDTO) =>
        {
            var editore = await db.Editori.FindAsync(id);
            if (editore is null)
            {
                return Results.NotFound();
            }
            editore.NomeEditore = editoreDTO.NomeEditore;
            editore.Città = editoreDTO.Citta;
            await db.SaveChangesAsync();
            return Results.Ok(editore);
        });
        //elimina un autore
        app.MapDelete("/api/editore/{id}", async (LibreriaContext db, int id) =>
        {
            var editore = await db.Editori.FindAsync(id);
            if (editore is null)
            {
                return Results.NotFound();
            }
            db.Editori.Remove(editore);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
        
    }
}
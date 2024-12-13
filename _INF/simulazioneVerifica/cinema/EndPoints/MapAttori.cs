using cinema.Models;
using cinema.Data;
using cinema.ModelsDTO;
using Microsoft.EntityFrameworkCore;
namespace cinema.EndPoints
{
    public static class AttoriEndPoints
    {
        public static void MapAttoriEndPoints(this WebApplication app)
        {
            app.MapGet("/attori", async (CinemaContext context) =>
            {
                var attori = await context.Attori.ToListAsync();
                return Results.Ok(attori);
            });
            app.MapGet("/attori/{id}", async (CinemaContext context, int id) =>
            {
                var attore = await context.Attori.FindAsync(id);
                if (attore == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(attore);
            });
            //post
            //put
            app.MapPut("/attori/{id}", async (CinemaContext context, int id, AttoreDTO attoreDTO) =>
            {
                var attore = await context.Attori.FindAsync(id);
                if (attore == null)
                {
                    return Results.NotFound();
                }
                attore.Nome = attoreDTO.Nome;
                attore.Cognome = attoreDTO.Cognome;
                attore.Eta = attoreDTO.Eta;
                await context.SaveChangesAsync();
                return Results.Ok(attore);
            });
            //delete
            app.MapDelete("/attori/{id}", async (CinemaContext context, int id) =>
            {
                var attore = await context.Attori.FindAsync(id);
                if (attore == null)
                {
                    return Results.NotFound();
                }
                context.Attori.Remove(attore);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
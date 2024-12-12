using cinema.Models;
namespace cinema.Data;
using Microsoft.EntityFrameworkCore;
public class CinemaContext:DbContext
{
    public DbSet<Attore> Attori { get; set; }=null!;
    public DbSet<Film> Film { get; set; }=null!;
    public DbSet<Regista> Registi { get; set; }=null!;
    public DbSet<FilmAttori> FilmAttori { get; set; }=null!;

    public CinemaContext(DbContextOptions<CinemaContext> options):base(options)
    {
    }
}
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
namespace MovieAPI.Data;
public class FilmContext:DbContext
{
    public DbSet<Regista> Regista { get; set; } = null!;
    public DbSet<Attore> Attore { get; set; } = null!;
    public DbSet<FilmAttori> FilmAtori { get; set; } = null!;
    public DbSet<Film> Film { get; set; } = null!;

    public FilmContext(DbContextOptions options ): base(options)
    {
        
    }
}

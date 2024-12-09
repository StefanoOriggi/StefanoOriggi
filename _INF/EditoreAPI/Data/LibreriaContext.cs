using Microsoft.EntityFrameworkCore;
using EditoreAPI.Model;
namespace EditoreAPI.Data;

public class LibreriaContext : DbContext
{
    public DbSet<Editore> Editori { get; set; }
    public DbSet<Libro> Libri { get; set; }

    public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
    {
    }
}
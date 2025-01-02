using Microsoft.EntityFrameworkCore;
namespace OriggiStefanoVerificaAPI_A;

public class VenditeDbContext:DbContext
{
    public DbSet<Prodotto> Prodotto { get; set; } = null!;
    public DbSet<Fornitore> Fornitore { get; set; } = null!;
    public DbSet<Cliente> Cliente { get; set; } = null!;
    public DbSet<Acquisti> Acquisti { get; set; } = null!;
    public VenditeDbContext(DbContextOptions<VenditeDbContext> options) : base(options)
    {

    }
}

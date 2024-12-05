using Microsoft.EntityFrameworkCore;
using PizzaStore.Model;
namespace PizzaStore.Data;

public class PizzaDb : DbContext
{
    public PizzaDb(DbContextOptions options) : base(options) { }
    public DbSet<Pizza> Pizzas => Set<Pizza>();
}

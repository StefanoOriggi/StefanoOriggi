using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using ClientiAPI.Model;
namespace ClientiAPI.Data;
public class ClienteContext:DbContext
{
    public ClienteContext(DbContextOptions options):base(options){ }
    public DbSet<Cliente> Clienti { get; set; }
}
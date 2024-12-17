using System;
using LibreriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApi.Data;

public class LibreriaContext:DbContext
{
    public DbSet<Editore> Editori { get; set; }=null!;
    public DbSet<Libro> Libri { get; set; }=null!;
    public LibreriaContext(DbContextOptions options):base(options)
    {
        
    }
    
}

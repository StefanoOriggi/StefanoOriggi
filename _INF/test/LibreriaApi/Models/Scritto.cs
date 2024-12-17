using Microsoft.EntityFrameworkCore;
namespace LibreriaApi.Models;
[PrimaryKey(nameof(AutoreId), nameof(LibroId))]
public class Scritto
{
    public int AutoreId { get; set; }
    public int LibroId { get; set; }
    public DateTime DataPubblicazione { get; set; }

    public Autore Autore { get; set; }=null!;
    public Libro Libro { get; set; }=null!;
}
using System.ComponentModel.DataAnnotations.Schema;

namespace EditoreAPI.Model;
public class Libro
{
    public int LibroId { get; set; }
    public string Titolo { get; set; }
    public double Prezzo { get; set; }
    public int numeroPagine { get; set; }
    public int EditoreId { get; set; }
    public Editore Editore { get; set; }
}
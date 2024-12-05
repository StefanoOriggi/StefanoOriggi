using System.ComponentModel.DataAnnotations.Schema;
namespace Azienda.Models;
public class Azienda
{
    [Column(TypeName="nvarchar(100)")]
    public int AziendaId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Nome { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string? Indirizzo { get; set; }

    List<Prodotto> Prodotti { get; set; } = [];
    List<Sviluppatore> Sviluppatori { get; set; } = [];
}
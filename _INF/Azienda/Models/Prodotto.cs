using System.ComponentModel.DataAnnotations.Schema;
namespace Azienda.Models;
public class Prodotto
{
    public int ProdottoId { get; set; }
    public int AziendaId { get; set; }
    public Azienda Azienda { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string Nome { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(200)")]
    public string? Descrizione { get; set; }
}

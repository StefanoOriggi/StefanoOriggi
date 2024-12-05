using System.ComponentModel.DataAnnotations.Schema;
namespace Azienda.Models;
public class Sviluppatore
{
    public int SviluppatoreId { get; set; }
    public int AziendaId { get; set; }

    [Column(TypeName = "nvarchar(40)")]
    public string Nome { get; set; } = null!;

    [Column(TypeName = "nvarchar(40)")]
    public string Cognome { get; set; } = null!;
    public Azienda Azienda { get; set; } = null!;
}


using Microsoft.EntityFrameworkCore;

namespace OriggiStefanoVerificaAPI_A;
[PrimaryKey (nameof(ClienteId), nameof(ProdottoID))]
public class Acquisti
{
    public int ClienteId { get; set; }
    public int ProdottoID { get; set; }
    public DateOnly DataAcquisto { get; set; }

    public Cliente Cliente { get; set; } = null!;
    public Prodotto Prodotto { get; set; } = null!;
}

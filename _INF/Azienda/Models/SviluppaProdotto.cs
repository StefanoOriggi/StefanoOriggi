namespace Azienda.Models;
public class SviluppaProdotto
{
    public int ProdottoId { get; set; }
    public Prodotto Prodotto { get; set; } = null!;
    public int SviluppatoreId { get; set; }
    public Sviluppatore Sviluppatore { get; set; } = null!;
}
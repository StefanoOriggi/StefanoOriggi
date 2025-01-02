namespace OriggiStefanoVerificaAPI_A;

public class Prodotto
{
    public int ProdottoId { get; set; }
    public string Nome { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public double Prezzo { get; set; }
    public int Quantita { get; set; }

    public int FornitoreId { get; set; }
    public Fornitore Fornitore { get; set; } = null!;

    public List<Acquisti> Acquisti { get; set; } = null!;
}

namespace OriggiStefanoVerificaAPI_A;

public class Fornitore
{
    public int FornitoreId { get; set; }
    public string Cognome { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Indirizzo { get; set; } = null!;
    public int Cap { get; set; } 

    public List<Prodotto> Prodotti { get; set; } = [];
}

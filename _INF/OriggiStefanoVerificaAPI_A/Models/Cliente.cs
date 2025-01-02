namespace OriggiStefanoVerificaAPI_A;

public class Cliente
{
    public int ClienteId { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public int NumeroCartaDiCredito { get; set; }
    public string Citta { get; set; } = null!;

    public List<Acquisti> Acquisti { get; set; } = null!;
    
}

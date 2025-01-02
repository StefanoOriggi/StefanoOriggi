namespace OriggiStefanoVerificaAPI_A;

public class FornitoreDTO
{
    public int FornitoreId { get; set; }
    public string Cognome { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Indirizzo { get; set; } = null!;
    public int Cap { get; set; }

    public FornitoreDTO(){}
    public FornitoreDTO(Fornitore Fornitore) => (FornitoreId, Cognome, Nome, Indirizzo,Cap)
        = (Fornitore.FornitoreId, Fornitore.Cognome, Fornitore.Nome, Fornitore.Indirizzo, Fornitore.Cap);
}

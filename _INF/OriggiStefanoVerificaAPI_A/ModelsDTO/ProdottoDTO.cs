namespace OriggiStefanoVerificaAPI_A;

public class ProdottoDTO
{
    public int ProdottoId { get; set; }
    public string Nome { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public double Prezzo { get; set; }
    public int Quantita { get; set; }

    public ProdottoDTO(){}
    public ProdottoDTO(Prodotto prodotto) => (ProdottoId,Nome,Marca,Prezzo,Quantita)
        = (prodotto.ProdottoId,prodotto.Nome,prodotto.Marca,prodotto.Prezzo,prodotto.Quantita);
}

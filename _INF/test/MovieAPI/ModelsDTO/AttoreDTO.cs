namespace MovieAPI.ModelsDTO;
using MovieAPI.Models;
public class AttoreDTO
{
    public int AttoreId { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public string Eta { get; set; } = null!;

    public AttoreDTO(){ }
    public AttoreDTO(Attore attore) => (AttoreId,Nome,Cognome,Eta) 
        = (attore.AttoreId,attore.Nome,attore.Cognome,attore.Eta);
}

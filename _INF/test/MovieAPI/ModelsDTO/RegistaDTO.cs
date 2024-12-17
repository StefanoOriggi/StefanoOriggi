using MovieAPI.Models;
namespace MovieAPI.ModelsDTO;
public class RegistaDTO
{
    public int RegistaId { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public string Nazionalita { get; set; } = null!;

    public RegistaDTO(){}

    public RegistaDTO(Regista regista) => (RegistaId,Nome,Cognome,Nazionalita) 
    = (regista.RegistaId,regista.Nome,regista.Cognome,regista.Nazionalita);
}

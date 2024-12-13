using cinema.Models;
namespace cinema.ModelsDTO
{
    public class RegistaDTO
    {
        public int RegistaId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Nazionalita { get; set; }

        public RegistaDTO() { }
        public RegistaDTO(Regista regista) => (RegistaId, Nome, Cognome, Nazionalita)=
        (regista.RegistaId, regista.Nome, regista.Cognome, regista.Nazionalita);
    }
}
using cinema.Models;

namespace cinema.ModelsDTO
{
    public class AttoreDTO
    {
        public int AttoreId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        public AttoreDTO() { }
        public AttoreDTO(Attore attore) => (AttoreId, Nome, Cognome, Eta) = (attore.AttoreId, attore.Nome, attore.Cognome, attore.Eta);

    }
}
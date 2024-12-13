using cinema.Models;
namespace cinema.ModelsDTO
{
    public class FilmAttoriDTO
    {
        public int FilmId { get; set; }
        public FilmDTO Film { get; set; }
        public int AttoreId { get; set; }
        public AttoreDTO Attore { get; set; }
        public DateTime DataPartecipazione { get; set; }

        public FilmAttoriDTO() { }
        public FilmAttoriDTO(FilmAttori filmAttori) => (FilmId, Film, AttoreId, Attore, DataPartecipazione) = (filmAttori.FilmId, new FilmDTO(filmAttori.Film), filmAttori.AttoreId, new AttoreDTO(filmAttori.Attore), filmAttori.DataPartecipazione);
    }
}
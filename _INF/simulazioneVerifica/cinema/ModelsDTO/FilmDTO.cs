using cinema.Models;
namespace cinema.ModelsDTO
{
    public class FilmDTO
    {
        public int FilmId { get; set; }
        public string Titolo { get; set; }
        public string DataUscita { get; set; }
        public string Genere { get; set; }
        public int RegistaId { get; set; }
        public RegistaDTO Regista { get; set; }

        public FilmDTO() { }
        public FilmDTO(Film film) => (FilmId, Titolo, DataUscita, Genere, RegistaId) = (film.FilmId, film.Titolo, film.DataUscita.ToString("dd/MM/yyyy"), film.Genere, film.RegistaId);
    }
}
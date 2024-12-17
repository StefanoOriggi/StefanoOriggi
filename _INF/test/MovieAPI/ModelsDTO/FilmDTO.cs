namespace MovieAPI.ModelsDTO;
using MovieAPI.Models;
public class FilmDTO
{
    public int FilmId { get; set; }
    public string Titolo { get; set; } = null!;
    public DateOnly Datauscita { get; set; }
    public string Genere { get; set; } = null!;
    public int RegistaId { get; set; }

    public FilmDTO(){}
    public FilmDTO(Film film) => (FilmId,Titolo,Datauscita,Genere,RegistaId) 
    = (film.FilmId,film.Titolo,film.Datauscita,film.Genere,film.RegistaId);
}

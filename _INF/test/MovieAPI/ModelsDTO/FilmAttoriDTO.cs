namespace MovieAPI.ModelsDTO;
using MovieAPI.Models;
public class FilmAttoriDTO
{
    public int FilmId { get; set; }
    public int AttoreId { get; set; }

    public DateOnly DataPartecipazione { get; set; }

    public FilmAttoriDTO(){}
    public FilmAttoriDTO(FilmAttori filmAttori) => (FilmId,AttoreId) 
    = (filmAttori.FilmId,filmAttori.AttoreId);
}

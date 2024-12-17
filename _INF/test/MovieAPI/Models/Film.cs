namespace MovieAPI.Models;

public class Film
{
    public int FilmId { get; set; }
    public string Titolo { get; set; } = null!;
    public DateOnly Datauscita { get; set; }
    public string Genere { get; set; } = null!;

    public int RegistaId { get; set; }
    public Regista Regista { get; set; } = null!;

    public List<FilmAttori> filmAttori { get; set; } = [];
}

namespace MovieAPI.Models;

public class Attore
{
    public int AttoreId { get; set;}
    public string Nome { get; set;} = null!;
    public string Cognome { get; set; } = null!;
    public string Eta { get; set; } = null!;

    public List<FilmAttori> FilmAttori { get; set; } = [];
}

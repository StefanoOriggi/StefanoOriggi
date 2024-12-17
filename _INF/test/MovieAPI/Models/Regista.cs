namespace MovieAPI.Models;

public class Regista
{
    public int RegistaId { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public string Nazionalita { get; set; } = null!;

    public List<Film> Films { get; set; } = [];
}

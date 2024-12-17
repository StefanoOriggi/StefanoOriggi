namespace LibreriaApi.Models;

public class Autore
{
    public int AutoreId { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime DataNascita { get; set; }

    public List<Scritto> Scritti { get; set; }=null!;
}
namespace EditoreAPI.Model;
public class Editore
{
    public int EditoreId { get; set; }
    public string NomeEditore { get; set; }
    public string citta { get; set; }
    public List<Libro> Libri { get; set; }
}
using Microsoft.EntityFrameworkCore;
namespace MovieAPI.Models;
[PrimaryKey (nameof(FilmId), nameof(AttoreId))]
public class FilmAttori
{
    public int FilmId { get; set; }
    public int AttoreId { get; set; }
    
    public DateOnly DataPartecipazione { get; set; }

    public Film Film { get; set; } = null!;
    public Attore Attori { get; set; } = null!;

}

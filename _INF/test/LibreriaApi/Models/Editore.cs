using System;

namespace LibreriaApi.Models;

public class Editore
{
    public int EditoreId { get; set; }
    public string NomeEditore { get; set; }=null!;
    public string  Città { get; set; }=null!;
    public List<Libro> Libri { get; set; }=[];

}

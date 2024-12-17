using System;

namespace LibreriaApi.Models;

public class Libro
{
   public int LibroId { get; set; }
   public string Titolo { get; set; }=null!;
   public double Prezzo { get; set; }
   public int NumeroPagine { get; set; }
   public int EditoreId { get; set; }
   public Editore Editore { get; set; }=null!;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaApi.Models;
namespace LibreriaApi.ModelsDTO
{
    public class LibroDTO
    {
        public int LibroId { get; set; }
        public string? Titolo { get; set; }
        public double Prezzo { get; set; }
        public int NumeroPagine { get; set; }
        public int EditoreId { get; set; }
        public LibroDTO()
        { }
        public LibroDTO(Libro libro) => (LibroId, Titolo, Prezzo, NumeroPagine, EditoreId) = (libro.LibroId, libro.Titolo, libro.Prezzo, libro.NumeroPagine, libro.EditoreId);
    }
}
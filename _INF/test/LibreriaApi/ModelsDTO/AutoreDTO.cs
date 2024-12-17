using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaApi.Models;
namespace LibreriaApi.ModelsDTO
{
    public class AutoreDTO
    {
        public int AutoreId { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public AutoreDTO()
        { }
        public AutoreDTO(Autore autore) => (AutoreId, Nome, Cognome) = (autore.AutoreId, autore.Nome, autore.Cognome);
    }
}
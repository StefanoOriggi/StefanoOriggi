using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace cinema.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Titolo { get; set; }
        public DateTime DataUscita { get; set; }
        public string Genere { get; set; }
        public int RegistaId { get; set; }
        public Regista Regista { get; set; }
    }
}
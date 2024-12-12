using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace cinema.Models
{
    public class Attore
    {
        public int AttoreId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }
    }
}
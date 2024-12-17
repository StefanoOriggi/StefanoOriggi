using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaApi.Models;
namespace LibreriaApi.ModelsDTO
{
    public class ScrittoDTO
    {
        public DateTime DataPubblicazione { get; set; }
        public int AutoreId { get; set; }
        public int LibroId { get; set; }
        public ScrittoDTO()
        { }
        public ScrittoDTO(Scritto scritto) => (DataPubblicazione, AutoreId, LibroId) = (scritto.DataPubblicazione, scritto.AutoreId, scritto.LibroId);
    }
}
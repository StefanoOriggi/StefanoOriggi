using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaApi.Models;
namespace LibreriaApi.ModelsDTO
{
    public class EditoreDTO
    {
        public int EditoreId { get; set; }
        public string? NomeEditore { get; set; }
        public string? Citta { get; set; }

        public EditoreDTO()
        { }
        public EditoreDTO(Editore editore) => (EditoreId, NomeEditore, Citta) = (editore.EditoreId, editore.NomeEditore, editore.Città);
    }
}
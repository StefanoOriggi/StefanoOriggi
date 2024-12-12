using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace cinema.Models
{
    [PrimaryKey (nameof(FilmId), nameof(AttoreId))]
    public class FilmAttori
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int AttoreId { get; set; }
        public Attore Attore { get; set; }

        public DateTime DataPartecipazione { get; set; }
    }
}
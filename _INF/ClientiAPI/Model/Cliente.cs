using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ClientiAPI.Model;
public class Cliente
{
    public int IdCliente { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Citta { get; set; }
    public string Professione { get; set; }
}
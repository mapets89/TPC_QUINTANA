using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carro
    {
        public List<Articulo> carro { get; set; }
        public int cantArt { get; set; }
        public decimal precioTotal { get; set; }
        public Carro()
        {
            carro = new List<Articulo>();
            cantArt = 0;
            precioTotal = 0;
        }
    }
}

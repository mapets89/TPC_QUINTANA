using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Carrito
    {
        public List<Articulo> carro { get; set; }
        public int cantArt { get; set; }
        public double precioTotal { get; set; }
    }
}

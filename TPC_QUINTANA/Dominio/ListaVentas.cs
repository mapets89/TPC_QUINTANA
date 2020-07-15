using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ListaVentas
    {
        public int idVenta { get; set; }
        public int cantidadProductos { get; set; }
        public decimal precioDeCompra { get; set; }
        public DateTime fechaDeCompra { get; set; }
        public ListaVentas()
        {
            idVenta = 0;
            cantidadProductos = 0;
            precioDeCompra = 0;
        }
    }
}

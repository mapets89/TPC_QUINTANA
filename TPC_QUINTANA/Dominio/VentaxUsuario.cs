using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VentaxUsuario
    {
        public int idArticulo { get; set; }
        public int idVenta { get; set; }
        public int cantidad { get; set; }
        public decimal money { get; set; }
        public VentaxUsuario()
        {
            idArticulo = 0;
            idVenta = 0;
            cantidad = 0;
            money = 0;
        }
    }
}

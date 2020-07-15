using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ventacs
    {
        public int idUsuario { get; set; }
        public int idVenta { get; set; }
        public decimal precioTotal { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public string nombreUsuario { get; set; }
        public Ventacs()
        {
            idUsuario = 0;
            idVenta = 0;
            precioTotal = 0;
            estado = 0;
            nombreUsuario = "";
        }
    }
}

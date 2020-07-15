using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Proveedor
    {
        public int cod { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Direccion direccion { get; set; }
        public int existencia { get; set; }
        public Proveedor()
        {
            cod = 0;
            nombre = "";
            descripcion = "";
            existencia = 1;
            direccion = new Direccion();
        }
    }
}

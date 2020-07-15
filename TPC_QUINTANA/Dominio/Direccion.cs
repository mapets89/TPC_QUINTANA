using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public int id { get; set; }
        public string calle { get; set; }
        public int altura { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string descripcion { get; set; }
        public Direccion()
        {
            id = 1;
            calle = "";
            altura = 0;
            localidad = "";
            provincia = "";
            descripcion = "";
        }
    }
}

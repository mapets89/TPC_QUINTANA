using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Seccion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Seccion()
        {
            id = 0;
            nombre = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Marca
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int existencia { get; set; }
        public Marca()
        {
            id = 0;
            nombre = "";
        }
    }
}

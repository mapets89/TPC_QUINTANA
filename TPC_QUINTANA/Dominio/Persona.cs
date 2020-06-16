using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public Fecha fechaNac { get; set; }
        public string direccion { get; set; }
    }
}

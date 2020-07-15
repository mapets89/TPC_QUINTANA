using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public Direccion direccion { get; set; }
        public Persona()
        {
            nombre = "";
            apellido = "";
            dni = 0;
            direccion = new Direccion();
        }
    }
}

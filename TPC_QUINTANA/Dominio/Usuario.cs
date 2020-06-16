using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Usuario
    {
        public string email { get; set; }
        public string password { get; set; }
        public int privilegio { get; set; }
        public Fecha fechaAlta { get; set; }
    }
}

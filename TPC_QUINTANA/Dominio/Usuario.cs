using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Usuario : Persona
    {
        public int id { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int privilegio { get; set; }
        public int existe { get; set; }
        public Usuario()
        {
            id = 0;
            email = "";
            userName = "";
            password = "";
            privilegio = 1;
            existe = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int id { get; set; }
        public string cod { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Categoria categoria { get; set; }
        public Seccion seccion { get; set; }
        public Marca marca { get; set; }
        public Proveedor proveedor { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public int stock { get; set; }
        public int existencia { get; set; }
        public Pais origen { get; set; }
        public string imagen { get; set; }
        public string enStock { get; set; }
        public Articulo()
        {
            cantidad = 1;
            categoria = new Categoria();
            proveedor = new Proveedor();
            seccion = new Seccion();
            marca = new Marca();
            origen = new Pais();
            enStock = "";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
        public Marca marca { get; set; }
        public Proveedor proveedor { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public int existencia { get; set; }
        public Pais origen { get; set; }
        public string imagen { get; set; }
        public Articulo()
        {
            categoria = new Categoria();
            proveedor = new Proveedor();
            marca = new Marca();
            origen = new Pais();
        }

    }
}

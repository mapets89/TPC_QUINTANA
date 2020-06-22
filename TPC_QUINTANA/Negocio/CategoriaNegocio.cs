using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {

        AccesoDB conexionDB = new AccesoDB();
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> listadoCategorias = new List<Categoria>();
            try
            {
                conexionDB.SetearSP("SP_LISTAR_CATEGORIAS");
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.id = conexionDB.lector.GetInt32(0);
                    categoria.nombre = (string)conexionDB.lector["nombreCategoria"];
                    listadoCategorias.Add(categoria);
                }
                return listadoCategorias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDB.cerrarConexion();
            }
        }
    }
}

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
        public void Agregar(string nombre)
        {
            try
            {
                conexionDB.SetearSP("SP_AGREGAR_CATEGORIA");
                conexionDB.agregarParametro("@Nombre", nombre);
                conexionDB.ejecutarAccion();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void Eliminar(Categoria categoria)
        {
            try
            {
                conexionDB.SetearSP("SP_ELIMINAR_CATEGORIA");
                conexionDB.agregarParametro("@ID", categoria.id);
                conexionDB.agregarParametro("@Existencia", categoria.existencia);
                conexionDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Modificar(Categoria categoria)
        {
            try
            {
                conexionDB.SetearSP("SP_MODIFICAR_CATEGORIA");
                conexionDB.agregarParametro("@ID", categoria.id);
                conexionDB.agregarParametro("@Nombre", categoria.nombre);
                conexionDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

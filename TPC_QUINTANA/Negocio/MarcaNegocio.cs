using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public List<Marca> ListarMarcas()
        {
            List<Marca> listadoMarcas = new List<Marca>();
            try
            {
                conexionDB.SetearSP("SP_LISTAR_MARCAS");
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    Marca marca = new Marca();
                    marca.id = conexionDB.lector.GetInt32(0);
                    marca.nombre = (string)conexionDB.lector["nombreMarca"];
                    listadoMarcas.Add(marca);
                }
                return listadoMarcas;
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
        public void AgregarMarca(string nombre)
        {
            try
            {
                conexionDB.SetearSP("SP_AGREGAR_MARCA");
                conexionDB.agregarParametro("@Nombre", nombre);
                conexionDB.ejecutarAccion();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void Eliminar(Marca marca)
        {
            try
            {
                conexionDB.SetearSP("SP_ELIMINAR_MARCA");
                conexionDB.agregarParametro("@ID", marca.id);
                conexionDB.agregarParametro("@Existencia", marca.existencia);
                conexionDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Modificar(Marca marca)
        {
            try
            {
                conexionDB.SetearSP("SP_MODIFICAR_MARCA");
                conexionDB.agregarParametro("@ID", marca.id);
                conexionDB.agregarParametro("@Nombre", marca.nombre);
                conexionDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

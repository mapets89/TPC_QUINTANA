using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public List<Proveedor> ListarProveedores()
        {
            List<Proveedor> listadoProveedores = new List<Proveedor>();
            try
            {
                conexionDB.SetearSP("SP_LISTAR_PROVEEDORES");
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.cod = conexionDB.lector.GetInt32(0);
                    proveedor.nombre = (string)conexionDB.lector["nombreProveedor"];
                    proveedor.descripcion = (string)conexionDB.lector["descripcionProveedor"];
                    proveedor.direccion = new Direccion();
                    proveedor.direccion.id = conexionDB.lector.GetInt32(3);
                    proveedor.direccion.calle = (string)conexionDB.lector["calleDireccion"];
                    proveedor.direccion.altura = (int)conexionDB.lector["alturaDireccion"];
                    proveedor.direccion.localidad = (string)conexionDB.lector["localidadDireccion"];
                    proveedor.direccion.provincia = (string)conexionDB.lector["provinciaDireccion"];
                    proveedor.direccion.descripcion = (string)conexionDB.lector["descripcionDireccion"];
                    listadoProveedores.Add(proveedor);
                }
                return listadoProveedores;
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

        public void Eliminar(Proveedor proveedor)
        {
            try
            {
                conexionDB.SetearSP("SP_ELIMINAR_PROVEEDOR");
                conexionDB.agregarParametro("@ID", proveedor.cod);
                conexionDB.agregarParametro("@Existencia", proveedor.existencia);
                conexionDB.ejecutarAccion();
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
        public void Modificar(Proveedor proveedor)
        {
            try
            {
                conexionDB.SetearSP("SP_MODIFICAR_PROVEEDOR");
                conexionDB.agregarParametro("@Id", proveedor.cod);
                conexionDB.agregarParametro("@Nombre", proveedor.nombre);
                conexionDB.agregarParametro("@Descripcion", proveedor.descripcion);
                conexionDB.agregarParametro("@IdDireccion", proveedor.direccion.id);
                conexionDB.ejecutarAccion();
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
        public void Agregar(Proveedor proveedor)
        {
            try
            {
                conexionDB.SetearSP("SP_AGREGAR_PROVEEDOR");
                conexionDB.agregarParametro("@Nombre", proveedor.nombre);
                conexionDB.agregarParametro("@Descripcion", proveedor.descripcion);
                conexionDB.agregarParametro("@IdDireccion", proveedor.direccion.id);
                conexionDB.ejecutarAccion();
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

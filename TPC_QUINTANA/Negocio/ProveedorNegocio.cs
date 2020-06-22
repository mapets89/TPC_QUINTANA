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
                    proveedor.direccion = (string)conexionDB.lector["direccionProveedor"];
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
    }
}

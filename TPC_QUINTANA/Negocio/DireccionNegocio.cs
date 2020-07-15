using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DireccionNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public void Modificar(Direccion direccion)
        {
            try
            {
                conexionDB.SetearSP("SP_MODIFICAR_DIRECCION");
                conexionDB.agregarParametro("@Id", direccion.id);
                conexionDB.agregarParametro("@Calle", direccion.calle);
                conexionDB.agregarParametro("@Altura", direccion.altura);
                conexionDB.agregarParametro("@Localidad", direccion.localidad);
                conexionDB.agregarParametro("@Provincia", direccion.provincia);
                conexionDB.agregarParametro("@Descripcion", direccion.descripcion);
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
        public void Agregar(Direccion direccion)
        {
            try
            {
                conexionDB.SetearSP("SP_AGREGAR_DIRECCION");
                conexionDB.agregarParametro("@Calle", direccion.calle);
                conexionDB.agregarParametro("@Altura", direccion.altura);
                conexionDB.agregarParametro("@Localidad", direccion.localidad);
                conexionDB.agregarParametro("@Provincia", direccion.provincia);
                conexionDB.agregarParametro("@Descripcion", direccion.descripcion);
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
        public int BuscarDireccion()
        {
            int id = 0;
            try
            {
                //conexionDB.SetearSP("SP_BUSCAR");
                conexionDB.setearQuery("EXEC SP_BUSCAR_DIRECCION"); 
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    id = conexionDB.lector.GetInt32(0);
                }
                return id;
                
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

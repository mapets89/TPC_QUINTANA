using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SeccionNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public List<Seccion> ListarSecciones()
        {
            List<Seccion> listadoSecciones = new List<Seccion>();
            try
            {
                conexionDB.SetearSP("SP_LISTAR_SECCIONES");
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    Seccion seccion = new Seccion();
                    seccion.id = conexionDB.lector.GetInt32(0);
                    seccion.nombre = (string)conexionDB.lector["nombreSeccion"];
                    listadoSecciones.Add(seccion);
                }
                return listadoSecciones;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PaisNegocio
    {

        AccesoDB conexionDB = new AccesoDB();
        public List<Pais> ListarPais()
        {
            List<Pais> listadoPais = new List<Pais>();
            try
            {
                conexionDB.SetearSP("SP_LISTAR_PAISES");
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    Pais pais = new Pais();
                    pais.id = conexionDB.lector.GetInt32(0);
                    pais.nombre = (string)conexionDB.lector["nombrePais"];
                    listadoPais.Add(pais);
                }
                return listadoPais;
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

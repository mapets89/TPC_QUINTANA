using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDB
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; }
        public SqlCommand comando { get; set; }
        public AccesoDB()
        {
            conexion = new SqlConnection(@"Server=localhost,1433;Database=ENCASA;User Id=sa;Password=Admin011");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        internal void ejecutarLector()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }
        internal void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void cerrarConexion()
        {
            conexion.Close();
        }

        public void SetearSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        internal void ejecutarAccion()
        {
            try
            {
                conexion.Open(); comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { conexion.Close(); }
        }
    }
}

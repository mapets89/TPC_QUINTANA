using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VentaNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public void Agregar(Ventacs venta)
        {
            try
            {
                conexionDB.SetearSP("SP_AGREGAR_VENTA");
                conexionDB.agregarParametro("@Idusuario", venta.idUsuario);
                conexionDB.agregarParametro("@Preciototal", venta.precioTotal);
                conexionDB.agregarParametro("@Fecha", venta.fecha);
                conexionDB.agregarParametro("@Estado", venta.estado);
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
        public int BuscarVenta()
        {
            int id = 0;
            try
            {
                //conexionDB.SetearSP("SP_BUSCAR_VENTA");
                conexionDB.setearQuery("EXEC SP_BUSCAR_VENTA");
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
        public List<Ventacs> TraerVenta(int idUsuario)
        {
            List<Ventacs> ventasList = new List<Ventacs>();
            Ventacs venta;
            conexionDB.agregarParametro("@idUsuario", idUsuario);
            conexionDB.SetearSP("SP_BUSCAR_VENTA_EXACTA");
            conexionDB.ejecutarLector();
            while (conexionDB.lector.Read())
            {
                venta = new Ventacs();
                venta.idUsuario = (int)conexionDB.lector["idUsuario"];
                venta.idVenta = (int)conexionDB.lector["idVenta"];
                venta.precioTotal = (decimal)conexionDB.lector["precioTotal"];
                venta.fecha = (DateTime)conexionDB.lector["fechaCompra"];
                venta.estado = (int)conexionDB.lector["estadoVenta"];
                ventasList.Add(venta);
            }
            return ventasList;

        }

        public List<Ventacs> ListarVentas()
        {
            List<Ventacs> ventasList = new List<Ventacs>();
            Ventacs venta;
            conexionDB.SetearSP("SP_LISTAR_VENTAS");
            conexionDB.ejecutarLector();
            while (conexionDB.lector.Read())
            {
                venta = new Ventacs();
                venta.idVenta = (int)conexionDB.lector["idVenta"];
                venta.idUsuario = (int)conexionDB.lector["idUsuario"];
                venta.nombreUsuario = (string)conexionDB.lector["nombreUsuario"];
                venta.fecha = (DateTime)conexionDB.lector["fechaVenta"];
                venta.precioTotal = (decimal)conexionDB.lector["precioVenta"];
                venta.estado = (int)conexionDB.lector["estadoVenta"];
                ventasList.Add(venta);
            }
            return ventasList;
        }
        public void Modificar(int estado, int idVenta)
        {
            conexionDB.SetearSP("SP_MODIFICAR_VENTA");
            conexionDB.agregarParametro("@idVenta", idVenta);
            conexionDB.agregarParametro("@estado", estado);
            conexionDB.ejecutarAccion();
        }
    }
}

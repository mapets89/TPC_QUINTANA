using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaXArticuloNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public void Agregar(VentaxUsuario venta)
        {
            try
            {
                // conexionDB.SetearSP("SP_VENTAS_X_ARTICULO");
                conexionDB.setearQuery("SP_VENTAS_X_ARTICULO " + venta.idArticulo + ", " + venta.idVenta + ", " + venta.cantidad + ", " + venta.money);
                // conexionDB.agregarParametro("@IdArticulo", venta.idArticulo);
                // conexionDB.agregarParametro("@IdVenta", venta.idVenta);
                // conexionDB.agregarParametro("@Cantidad", venta.cantidad);
                // conexionDB.agregarParametro("@Precio", venta.money);
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
        public List<VentaxUsuario> ListarventasxUsuario(int idUsuario)
        {
            List<VentaxUsuario> listadoVentasxUsuario = new List<VentaxUsuario>();
            VentaxUsuario venta;
            try
            {
                conexionDB.SetearSP("SP_LISTA_COMPRAS_X_USUARIO");
                conexionDB.agregarParametro("@idUsuario", idUsuario);
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    venta = new VentaxUsuario();
                    venta.cantidad = (int)conexionDB.lector["cantXArticulo"];
                    venta.money = (decimal)conexionDB.lector["precioXArticulo"];
                    venta.idArticulo = (int)conexionDB.lector["idArticulo"];
                    venta.idVenta = (int)conexionDB.lector["idVenta"];
                    listadoVentasxUsuario.Add(venta);


                }
                return listadoVentasxUsuario;
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

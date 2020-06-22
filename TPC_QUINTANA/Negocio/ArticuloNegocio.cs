using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> listadoArticulo = new List<Articulo>();
            Articulo articulo;
            try
            {
                conexionDB.SetearSP("SP_LISTAR_ARTICULOS");
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    articulo = new Articulo();
                    articulo.id = conexionDB.lector.GetInt32(0);
                    articulo.cod = conexionDB.lector.GetString(1);
                    articulo.nombre = conexionDB.lector.GetString(2);
                    articulo.descripcion = conexionDB.lector.GetString(3);
                    articulo.existencia = conexionDB.lector.GetInt32(4);
                    articulo.imagen = conexionDB.lector.GetString(5);
                    articulo.precio = Decimal.Round((decimal)conexionDB.lector["PRECIO"], 2);
                    articulo.cantidad = conexionDB.lector.GetInt32(7);
                    articulo.marca = new Marca();
                    articulo.marca.nombre = (string)conexionDB.lector["nombreMarca"];
                    articulo.marca.id = conexionDB.lector.GetInt32(9);
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombre = (string)conexionDB.lector["nombreCat"];
                    articulo.categoria.id = conexionDB.lector.GetInt32(11);
                    articulo.origen = new Pais();
                    articulo.origen.nombre = (string)conexionDB.lector["paisOrig"];
                    articulo.origen.id = conexionDB.lector.GetInt32(13);

                    if (articulo.existencia != 0)
                    {
                        listadoArticulo.Add(articulo);
                    }

                }
                return listadoArticulo;
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
        public void Agregar(Articulo articuloNuevo)
        {
            try
            {
                conexionDB.SetearSP("SP_AGREGAR");
                conexionDB.agregarParametro("@Codigo", articuloNuevo.cod);
                conexionDB.agregarParametro("@Nombre", articuloNuevo.nombre);
                conexionDB.agregarParametro("@Descripcion", articuloNuevo.descripcion);
                conexionDB.agregarParametro("@IdCategoria", articuloNuevo.categoria.id.ToString());
                conexionDB.agregarParametro("@IdMarca", articuloNuevo.marca.id.ToString());
                conexionDB.agregarParametro("@IdProveedor", articuloNuevo.proveedor.cod.ToString());
                conexionDB.agregarParametro("@Precio", articuloNuevo.precio);
                conexionDB.agregarParametro("@Cantidad", articuloNuevo.cantidad);
                conexionDB.agregarParametro("@IdOrigen", articuloNuevo.origen.id.ToString());
                conexionDB.agregarParametro("@Imagen", articuloNuevo.imagen);
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

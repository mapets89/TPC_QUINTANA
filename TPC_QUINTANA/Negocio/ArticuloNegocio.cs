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
                    articulo.stock = conexionDB.lector.GetInt32(7);
                    articulo.marca = new Marca();
                    articulo.marca.nombre = (string)conexionDB.lector["nombreMarca"];
                    articulo.marca.id = conexionDB.lector.GetInt32(9);
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombre = (string)conexionDB.lector["nombreCat"];
                    articulo.categoria.id = conexionDB.lector.GetInt32(11);
                    articulo.seccion = new Seccion();
                    articulo.seccion.id = conexionDB.lector.GetInt32(12);
                    articulo.seccion.nombre = (string)conexionDB.lector["nombreSec"];
                    articulo.origen = new Pais();
                    articulo.origen.nombre = (string)conexionDB.lector["paisOrig"];
                    articulo.origen.id = conexionDB.lector.GetInt32(15);

                    if (articulo.existencia != 0)
                    {
                        if(articulo.stock == 0)
                        {
                            articulo.enStock = "Producto sin Stock";
                        }
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
        public List<Articulo> ListarDormitorio()
        {
            List<Articulo> listadoArticulo = new List<Articulo>();
            Articulo articulo;
            try
            {
                conexionDB.SetearSP("SP_LISTAR_DORMITORIO");
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
                    articulo.stock = conexionDB.lector.GetInt32(7);
                    articulo.marca = new Marca();
                    articulo.marca.nombre = (string)conexionDB.lector["nombreMarca"];
                    articulo.marca.id = conexionDB.lector.GetInt32(9);
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombre = (string)conexionDB.lector["nombreCat"];
                    articulo.categoria.id = conexionDB.lector.GetInt32(11);
                    articulo.seccion = new Seccion();
                    articulo.seccion.id = conexionDB.lector.GetInt32(12);
                    articulo.seccion.nombre = (string)conexionDB.lector["nombreSec"];
                    articulo.origen = new Pais();
                    articulo.origen.nombre = (string)conexionDB.lector["paisOrig"];
                    articulo.origen.id = conexionDB.lector.GetInt32(15);

                    if (articulo.existencia != 0)
                    {
                        if (articulo.stock == 0)
                        {
                            articulo.enStock = "Producto sin Stock";
                        }
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
        public List<Articulo> ListarLiving()
        {
            List<Articulo> listadoArticulo = new List<Articulo>();
            Articulo articulo;
            try
            {
                conexionDB.SetearSP("SP_LISTAR_LIVING");
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
                    articulo.stock = conexionDB.lector.GetInt32(7);
                    articulo.marca = new Marca();
                    articulo.marca.nombre = (string)conexionDB.lector["nombreMarca"];
                    articulo.marca.id = conexionDB.lector.GetInt32(9);
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombre = (string)conexionDB.lector["nombreCat"];
                    articulo.categoria.id = conexionDB.lector.GetInt32(11);
                    articulo.seccion = new Seccion();
                    articulo.seccion.id = conexionDB.lector.GetInt32(12);
                    articulo.seccion.nombre = (string)conexionDB.lector["nombreSec"];
                    articulo.origen = new Pais();
                    articulo.origen.nombre = (string)conexionDB.lector["paisOrig"];
                    articulo.origen.id = conexionDB.lector.GetInt32(15);

                    if (articulo.existencia != 0)
                    {
                        if (articulo.stock == 0)
                        {
                            articulo.enStock = "Producto sin Stock";
                        }
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
        public List<Articulo> ListarBaño()
        {
            List<Articulo> listadoArticulo = new List<Articulo>();
            Articulo articulo;
            try
            {
                conexionDB.SetearSP("SP_LISTAR_BANIO");
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
                    articulo.stock = conexionDB.lector.GetInt32(7);
                    articulo.marca = new Marca();
                    articulo.marca.nombre = (string)conexionDB.lector["nombreMarca"];
                    articulo.marca.id = conexionDB.lector.GetInt32(9);
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombre = (string)conexionDB.lector["nombreCat"];
                    articulo.categoria.id = conexionDB.lector.GetInt32(11);
                    articulo.seccion = new Seccion();
                    articulo.seccion.id = conexionDB.lector.GetInt32(12);
                    articulo.seccion.nombre = (string)conexionDB.lector["nombreSec"];
                    articulo.origen = new Pais();
                    articulo.origen.nombre = (string)conexionDB.lector["paisOrig"];
                    articulo.origen.id = conexionDB.lector.GetInt32(15);

                    if (articulo.existencia != 0)
                    {
                        if (articulo.stock == 0)
                        {
                            articulo.enStock = "Producto sin Stock";
                        }
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
        public List<Articulo> ListarCocina()
        {
            List<Articulo> listadoArticulo = new List<Articulo>();
            Articulo articulo;
            try
            {
                conexionDB.SetearSP("SP_LISTAR_COCINA");
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
                    articulo.stock = conexionDB.lector.GetInt32(7);
                    articulo.marca = new Marca();
                    articulo.marca.nombre = (string)conexionDB.lector["nombreMarca"];
                    articulo.marca.id = conexionDB.lector.GetInt32(9);
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombre = (string)conexionDB.lector["nombreCat"];
                    articulo.categoria.id = conexionDB.lector.GetInt32(11);
                    articulo.seccion = new Seccion();
                    articulo.seccion.id = conexionDB.lector.GetInt32(12);
                    articulo.seccion.nombre = (string)conexionDB.lector["nombreSec"];
                    articulo.origen = new Pais();
                    articulo.origen.nombre = (string)conexionDB.lector["paisOrig"];
                    articulo.origen.id = conexionDB.lector.GetInt32(15);

                    if (articulo.existencia != 0)
                    {
                        if (articulo.stock == 0)
                        {
                            articulo.enStock = "Producto sin Stock";
                        }
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
                conexionDB.SetearSP("SP_AGREGAR_ARTICULO");
                conexionDB.agregarParametro("@Codigo", articuloNuevo.cod);
                conexionDB.agregarParametro("@Nombre", articuloNuevo.nombre);
                conexionDB.agregarParametro("@Descripcion", articuloNuevo.descripcion);
                conexionDB.agregarParametro("@IdCategoria", articuloNuevo.categoria.id.ToString());
                conexionDB.agregarParametro("@IdSeccion", articuloNuevo.seccion.id.ToString());
                conexionDB.agregarParametro("@IdMarca", articuloNuevo.marca.id.ToString());
                conexionDB.agregarParametro("@IdProveedor", articuloNuevo.proveedor.cod.ToString());
                conexionDB.agregarParametro("@Precio", articuloNuevo.precio);
                conexionDB.agregarParametro("@Stock", articuloNuevo.stock);
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

        public void Modificar(Articulo articuloNuevo)
        {
            try
            {
                conexionDB.SetearSP("SP_MODIFICAR_ARTICULO");
                conexionDB.agregarParametro("@ID", articuloNuevo.id);
                conexionDB.agregarParametro("@Codigo", articuloNuevo.cod);
                conexionDB.agregarParametro("@Nombre", articuloNuevo.nombre);
                conexionDB.agregarParametro("@Descripcion", articuloNuevo.descripcion);
                conexionDB.agregarParametro("@IdCategoria", articuloNuevo.categoria.id.ToString());
                conexionDB.agregarParametro("@IdSeccion", articuloNuevo.seccion.id.ToString());
                conexionDB.agregarParametro("@IdMarca", articuloNuevo.marca.id.ToString());
                conexionDB.agregarParametro("@IdProveedor", articuloNuevo.proveedor.cod.ToString());
                conexionDB.agregarParametro("@Precio", articuloNuevo.precio);
                conexionDB.agregarParametro("@Stock", articuloNuevo.stock);
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

        public void Eliminar(Articulo articuloNuevo)
        {
            try
            {
                conexionDB.SetearSP("SP_ELIMINAR_ARTICULO");
                conexionDB.agregarParametro("@ID", articuloNuevo.id);
                conexionDB.agregarParametro("@Existencia", articuloNuevo.existencia);
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
        public void Venta(int idArticulo, int cantidadVendida)
        {
            try
            {
                conexionDB.setearQuery("EXEC SP_VENTA " + idArticulo + ", " + cantidadVendida );
                //conexionDB.agregarParametro("@Idarticulo", idArticulo);
                //conexionDB.agregarParametro("@Cantidadvendida", cantidadVendida);
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

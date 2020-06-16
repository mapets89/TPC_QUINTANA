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
                conexionDB.setearQuery("SELECT a.ID, A.CODIGO, a.NOMBRE, a.DESCRIPCION, a.EXISTENCIA, a.IMAGEN, a.PRECIO, a.CANTIDAD," +
                    " m.NOMBRE as nombreMarca, m.ID as idMarca, c.NOMBRE as nombreCat, c.ID as idCat, p.NOMBRE as paisOrig, p.ID " +
                    "as idOrig FROM Articulos as A INNER JOIN MARCAS as M on m.ID = a.IDMARCA INNER JOIN Categorias as C on " +
                    "C.ID = a.IDCATEGORIA INNER JOIN PAISES AS P ON P.ID = A.IDORIGEN");
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
    }
}

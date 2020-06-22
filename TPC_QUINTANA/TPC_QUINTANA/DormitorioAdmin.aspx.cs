using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_QUINTANA
{
    public partial class DormitorioAdmin : System.Web.UI.Page
    {
        protected List<Articulo> ListaFiltrada = new List<Articulo>();
        protected ArticuloNegocio negocioArticulo = new ArticuloNegocio();
        protected MarcaNegocio negocioMarca = new MarcaNegocio();
        protected ProveedorNegocio negocioProveedor = new ProveedorNegocio();
        protected CategoriaNegocio negocioCategoria = new CategoriaNegocio();
        protected PaisNegocio negocioPais = new PaisNegocio();
        Articulo articulo = new Articulo();
        public List<Articulo> ArticulosList { get; set; }
        public List<Marca> MarcasList { get; set; }
        public List<Proveedor> ProveedorList { get; set; } 
        public List<Categoria> CategoriaList { get; set; }
        public List<Pais> PaisList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                ArticulosList = negocioArticulo.ListarArticulos();
                MarcasList = negocioMarca.ListarMarcas();
                ProveedorList = negocioProveedor.ListarProveedores();
                CategoriaList = negocioCategoria.ListarCategorias();
                PaisList = negocioPais.ListarPais();
                if (!IsPostBack)
                {
                    Repeater.DataSource = ArticulosList;
                    ddlProveedor.DataSource = ProveedorList;
                    ddlMarca.DataSource = MarcasList;
                    ddlCategoria.DataSource = CategoriaList;
                    ddlOrigen.DataSource = PaisList;
                    Repeater.DataBind();
                    ddlProveedor.DataBind();
                    ddlMarca.DataBind();
                    ddlCategoria.DataBind();
                    ddlOrigen.DataBind();
                }
                else
                {
                    // Repeater.DataSource = ListaFiltrada;
                    Repeater.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void modificar_Command(object sender, CommandEventArgs e)
        {

        }

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Session[Session.SessionID + "marca"] == null)
                {
                    articulo.marca.id = Convert.ToInt32(ddlMarca.SelectedValue);
                    Session.Add(Session.SessionID + "marca", articulo.marca.id);
                }
                else if(articulo.marca.id == 0)
                {
                    articulo.marca.id = Convert.ToInt32(ddlMarca.SelectedValue);
                    Session.Add(Session.SessionID + "marca", articulo.marca.id);
                }
            }
            catch
            {

            }
        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (Session[Session.SessionID + "categoria"] == null)
                {
                    articulo.categoria.id = Convert.ToInt32(ddlCategoria.SelectedValue);
                    Session.Add(Session.SessionID + "categoria", articulo.categoria.id);
                }
                else if (articulo.marca.id == 0)
                {
                    articulo.categoria.id = Convert.ToInt32(ddlCategoria.SelectedValue);
                    Session.Add(Session.SessionID + "categoria", articulo.categoria.id);
                }


            }
            catch
            {
 
            }
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (Session[Session.SessionID + "proveedor"] == null)
                {
                    articulo.proveedor.cod = Convert.ToInt32(ddlProveedor.SelectedValue);
                    Session.Add(Session.SessionID + "proveedor", articulo.proveedor.cod);
                }
                else if (articulo.marca.id == 0)
                {
                    articulo.proveedor.cod = Convert.ToInt32(ddlProveedor.SelectedValue);
                    Session.Add(Session.SessionID + "proveedor", articulo.proveedor.cod);
                }
            }
            catch
            {

            }
        }

        protected void ddlOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (Session[Session.SessionID + "pais"] == null)
                {
                    articulo.origen.id = Convert.ToInt32(ddlOrigen.SelectedValue);
                    Session.Add(Session.SessionID + "pais", articulo.origen.id);
                }
                else if (articulo.marca.id == 0)
                {
                    articulo.origen.id = Convert.ToInt32(ddlOrigen.SelectedValue);
                    Session.Add(Session.SessionID + "pais", articulo.origen.id);
                }
            }
            catch
            {

            }
        }

        protected void cargar_Click(object sender, EventArgs e)
        {
            articulo.cantidad = Convert.ToInt32(cantidad.Text.ToString());
            articulo.precio = Convert.ToDecimal(precio.Text);
            articulo.nombre = nombreArt.Text;
            articulo.descripcion = descripArt.Text;
            articulo.cod = codigoArt.Text;
            articulo.imagen = imagen.Text;
            //articulo.origen.id = (int)Session[Session.SessionID + "pais"];
            articulo.origen.id = Convert.ToInt32(ddlOrigen.SelectedValue);
            articulo.marca.id = (int)Session[Session.SessionID + "marca"];
            articulo.categoria.id = (int)Session[Session.SessionID + "categoria"];
            articulo.proveedor.cod = (int)Session[Session.SessionID + "proveedor"];
            negocioArticulo.Agregar(articulo);
        }

      
    }
}
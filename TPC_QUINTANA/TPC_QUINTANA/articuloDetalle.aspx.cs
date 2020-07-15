using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;

namespace TPC_QUINTANA
{
    public partial class articuloDetalle : System.Web.UI.Page
    {
        protected ArticuloNegocio negocioArticulo = new ArticuloNegocio();
        protected MarcaNegocio negocioMarca = new MarcaNegocio();
        protected ProveedorNegocio negocioProveedor = new ProveedorNegocio();
        protected SeccionNegocio negocioSeccion = new SeccionNegocio();
        protected CategoriaNegocio negocioCategoria = new CategoriaNegocio();
        protected PaisNegocio negocioPais = new PaisNegocio();
        Articulo articulo = new Articulo();
        int idMarca;
        int idProveedor;
        int idCategoria;
        int idSeccion;
        int idOrigen;
        public List<Marca> MarcasList { get; set; }
        public List<Proveedor> ProveedorList { get; set; }
        public List<Categoria> CategoriaList { get; set; }
        public List<Seccion> SeccionList { get; set; }
        public List<Pais> PaisList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcasList = negocioMarca.ListarMarcas();
            ProveedorList = negocioProveedor.ListarProveedores();
            CategoriaList = negocioCategoria.ListarCategorias();
            SeccionList = negocioSeccion.ListarSecciones();
            PaisList = negocioPais.ListarPais();
            try
            {
                if (Session[Session.SessionID + "modificar"] != null)
                {
                    if (!IsPostBack)
                    {
                        articulo = (Articulo)Session[Session.SessionID + "modificar"];
                        nombreArt.Text = articulo.nombre;
                        codigoArt.Text = articulo.cod;
                        descripArt.Text = articulo.descripcion;
                        precio.Text = articulo.precio.ToString();
                        imagen.Text = articulo.imagen;
                        stock.Text = articulo.stock.ToString();  
                    }

                }
                else
                {
                    Session.Add(Session.SessionID + "modificar", articulo);
                    nombreArt.Attributes.Add("placeholder", "Introduzca un nombre");
                    codigoArt.Attributes.Add("placeholder", "Introduzca el Codigo");
                    descripArt.Attributes.Add("placeholder", "Introduzca una descripcion");
                    precio.Attributes.Add("placeholder", "Introduzco un precio");
                    imagen.Attributes.Add("placeholder", "Introduzca una imagen");
                    stock.Attributes.Add("placeholder", "Introduzca el stock del articulo");
                    botonDetalleArticulo.Text = "Agregar";
                }
                ddlProveedor.Items.Add("--- Seleccione un Proveedor ---");
                ddlMarca.Items.Add("--- Seleccione una Marca ---");
                ddlCategoria.Items.Add("--- Seleccione una Categoria ---");
                ddlOrigen.Items.Add("--- Seleccione un Origen ---");
                ddlSeccion.Items.Add("--- Seleccione una Seccion ---");
                ddlProveedor.AppendDataBoundItems = true;
                ddlMarca.AppendDataBoundItems = true;
                ddlCategoria.AppendDataBoundItems = true;
                ddlOrigen.AppendDataBoundItems = true;
                ddlSeccion.AppendDataBoundItems = true;
                ddlProveedor.DataSource = ProveedorList;
                ddlMarca.DataSource = MarcasList;
                ddlCategoria.DataSource = CategoriaList;
                ddlOrigen.DataSource = PaisList;
                ddlSeccion.DataSource = SeccionList;
                ddlProveedor.DataBind();
                ddlMarca.DataBind();
                ddlCategoria.DataBind();
                ddlOrigen.DataBind();
                ddlSeccion.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            }
            catch
            {

            }

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idCategoria = Convert.ToInt32(ddlCategoria.SelectedValue);
            }
            catch
            {

            }
        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idSeccion = Convert.ToInt32(ddlSeccion.SelectedValue);
            }
            catch
            {

            }
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
            }
            catch
            {

            }
        }

        protected void ddlOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                idOrigen = Convert.ToInt32(ddlOrigen.SelectedValue);
            }
            catch
            {

            }
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            articulo = (Articulo)Session[Session.SessionID + "modificar"];
            articulo.seccion.id = idSeccion;
            articulo.proveedor.cod = idProveedor;
            articulo.origen.id = idOrigen;
            articulo.categoria.id = idCategoria;
            articulo.marca.id = idMarca;
            articulo.stock = Convert.ToInt32(stock.Text.ToString());
            articulo.precio = Convert.ToDecimal(precio.Text);
            articulo.nombre = nombreArt.Text;
            articulo.descripcion = descripArt.Text;
            articulo.cod = codigoArt.Text;
            articulo.imagen = imagen.Text;
            if(botonDetalleArticulo.Text == "Agregar")
            {
                negocioArticulo.Agregar(articulo);
            }
            else
            {
                negocioArticulo.Modificar(articulo);
            }
            Response.Redirect("principalAdmin.aspx");
        }
    }
}
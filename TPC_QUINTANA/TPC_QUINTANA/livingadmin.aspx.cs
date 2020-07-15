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
    public partial class livingadmin : System.Web.UI.Page
    {
        protected ArticuloNegocio negocioArticulo = new ArticuloNegocio();
        protected MarcaNegocio negocioMarca = new MarcaNegocio();
        protected ProveedorNegocio negocioProveedor = new ProveedorNegocio();
        protected SeccionNegocio negocioSeccion = new SeccionNegocio();
        protected CategoriaNegocio negocioCategoria = new CategoriaNegocio();
        protected PaisNegocio negocioPais = new PaisNegocio();
        Articulo articulo = new Articulo();
        public List<Articulo> ArticulosList { get; set; }
        public List<Marca> MarcasList { get; set; }
        public List<Proveedor> ProveedorList { get; set; }
        public List<Categoria> CategoriaList { get; set; }
        public List<Seccion> SeccionList { get; set; }
        public List<Pais> PaisList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ArticulosList = negocioArticulo.ListarLiving();
                MarcasList = negocioMarca.ListarMarcas();
                ProveedorList = negocioProveedor.ListarProveedores();
                CategoriaList = negocioCategoria.ListarCategorias();
                SeccionList = negocioSeccion.ListarSecciones();
                PaisList = negocioPais.ListarPais();
                if (!IsPostBack)
                {
                    Repeater.DataSource = ArticulosList;
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
            int id = Convert.ToInt32(e.CommandArgument);
            foreach (Articulo item in ArticulosList)
            {
                if (item.id == id)
                {
                    Session.Add(Session.SessionID + "modificar", item);
                    break;
                }
            }
            Response.Redirect("articuloDetalle.aspx");

        }

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                foreach (Articulo item in ArticulosList)
                {
                    item.existencia = 0;
                    negocioArticulo.Eliminar(item);
                    break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("articuloDetalle.aspx");
        }
    }
}
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
    public partial class detalleVenta : System.Web.UI.Page
    {
        public List<Articulo> ArticulosList { get; set; }
        protected List<Articulo> ListaFiltrada = new List<Articulo>();
        protected ArticuloNegocio negocio = new ArticuloNegocio();
        VentaXArticuloNegocio ventaXArticuloNegocio = new VentaXArticuloNegocio();
        List<VentaxUsuario> ventaxUsuarioList = new List<VentaxUsuario>();
        List<VentaxUsuario> ventaxUsuarioListFiltrada = new List<VentaxUsuario>();
        VentaxUsuario ventaxUsuario = new VentaxUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[Session.SessionID + "venta"] != null)
                {
                    Articulo articulo;
                    int idVenta = (int)Session[Session.SessionID + "venta"];
                    Usuario usuario = (Usuario)Session[Session.SessionID + "usuario"];
                    ArticulosList = negocio.ListarArticulos();
                    ventaxUsuarioList = ventaXArticuloNegocio.ListarventasxUsuario(usuario.id);
                    ventaxUsuarioListFiltrada = ventaxUsuarioList.FindAll(k => k.idVenta == idVenta);
                    foreach(var item in ventaxUsuarioListFiltrada)
                    {
                        articulo = ArticulosList.Find(j => j.id == item.idArticulo);
                        articulo.cantidad = item.cantidad;
                        articulo.precio = item.money;
                        ListaFiltrada.Add(articulo);
                    }
                    if (!IsPostBack)
                    {
                        Repeater.DataSource = ListaFiltrada;
                        Repeater.DataBind();
                    }
                    else
                    {
                        // Repeater.DataSource = ListaFiltrada;
                        Repeater.DataBind();
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
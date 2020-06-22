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
    public partial class principalAdmin : System.Web.UI.Page
    {
        public List<Articulo> ArticulosList { get; set; }
        protected List<Articulo> ListaFiltrada = new List<Articulo>();
        protected ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {

                ArticulosList = negocio.ListarArticulos();
                if (!IsPostBack)
                {
                    Repeater.DataSource = ArticulosList;
                    Repeater.DataBind();
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
    }
}
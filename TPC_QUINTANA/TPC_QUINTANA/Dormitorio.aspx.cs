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
    public partial class Dormitorio : System.Web.UI.Page
    {
        public List<Articulo> DormitorioList { get; set; }
        protected ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                DormitorioList = negocio.ListarArticulos();
                if (!IsPostBack)
                {
                    Repeater.DataSource = DormitorioList;
                    Repeater.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
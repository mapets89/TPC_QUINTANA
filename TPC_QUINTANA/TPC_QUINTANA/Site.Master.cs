using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_QUINTANA
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Carro carro = new Carro();
            try
            {

                if (!IsPostBack && Session[Session.SessionID + "articulo"] == null)
                {
                    CantCarrito.Text = "0";
                    Session.Add(Session.SessionID + "articulo", carro);
                    CantCarrito.BackColor = System.Drawing.Color.Transparent;

                }
                else
                {
                    carro = (Carro)Session[Session.SessionID + "articulo"];
                    CantCarrito.Text = carro.cantArt.ToString();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_QUINTANA
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[Session.SessionID + "admin"] != null)
            {
                usuario = (Usuario)Session[Session.SessionID + "admin"];   
                nameAdmin.Text = "Hola " + usuario.nombre;

            }
            else
            {
                Response.Redirect("home.aspx");
            }

        }

        protected void salir_Click(object sender, EventArgs e)
        {
            Session.Remove(Session.SessionID + "admin");
            Response.Redirect("home.aspx");
        }
    }
}
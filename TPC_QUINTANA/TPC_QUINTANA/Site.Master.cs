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
        Usuario user = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            Carro carro = new Carro();
            try
            {
                Session.Remove(Session.SessionID + "busqueda");
                if (!IsPostBack)
                {

                    if (Session[Session.SessionID + "articulo"] == null)
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
                    if (Session[Session.SessionID + "usuario"] == null && Session[Session.SessionID + "admin"] == null)
                    {
                        ddlLogin.Items.Add("Login");
                        ddlLogin.Items.Add("Logeate");
                        ddlLogin.BackColor = System.Drawing.Color.Transparent;
                        ddlLogin.BorderColor = System.Drawing.Color.Transparent;
                        ddlLogin.AppendDataBoundItems = true;
                        ddlLogin.DataBind();
                    }
                    else
                    {
                        user = (Usuario)Session[Session.SessionID + "usuario"];
                        ddlLogin.BackColor = System.Drawing.Color.Transparent;
                        ddlLogin.BorderColor = System.Drawing.Color.Transparent;
                        ddlLogin.Items.Clear();
                        ddlLogin.AppendDataBoundItems = true;
                        ddlLogin.DataBind();
                        ddlLogin.Items.Add(user.userName);
                        ddlLogin.Items.Add("Mis Compras");
                        ddlLogin.Items.Add("Mis Datos");
                        ddlLogin.Items.Add("Salir");
                        ddlLogin.AppendDataBoundItems = true;
                        ddlLogin.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void ddlLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToString(ddlLogin.Text))
            {
                case "Logeate":
                    {
                        Response.Redirect("login.aspx");
                        break;
                    }
                case "Mis Compras":
                    {
                        Response.Redirect("compras.aspx");
                        break;
                    }
                case "Mis Datos":
                    {
                        Response.Redirect("detalleuser.aspx");
                        break;
                    }
                case "Salir":
                    {
                        Session.Remove(Session.SessionID + "usuario");
                        Response.Redirect("home.aspx");
                        break;
                    }
            }
        }

        protected void boton_busqueda_Click(object sender, EventArgs e)
        {
            Session.Add(Session.SessionID + "busqueda", busqueda.Text);
        }
    }
}
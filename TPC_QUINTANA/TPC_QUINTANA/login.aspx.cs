using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_QUINTANA
{
    public partial class login : System.Web.UI.Page
    {
        Usuario user = new Usuario();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usuario.Attributes.Add("placeholder", "Ingrese usuario");
                mail.Attributes.Add("placeholder", "Ingrese un mail");
                userTxt.Attributes.Add("placeholder", "Ingrese un nombre de usuario");
                pass.Attributes.Add("placeholder", "Ingrese una contraseña mas de 8 caracteres");
                confirmPass.Attributes.Add("placeholder", "Repita la contraseña por favor");
                validation.Attributes["class"] = "invisible alert alert-danger";
            }
        }

        protected void RegistrarButton_Click(object sender, EventArgs e)
        {
            user.userName = userTxt.Text;
            user.email = mail.Text;
            user.password = pass.Text;
            usuarioNegocio.Agregar(user);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            user.email = mail.Text;
            user.userName = usuario.Text;
            int encontro = usuarioNegocio.BuscarUsuario(user);
            if(encontro == 1)
            {
                usuarioNegocio.DetalleUsuario(user);
                if(user.password != password.Text)
                {
                    validation.Attributes["class"] = "visible alert alert-danger";
                    validation.InnerText = "Contraseña incorrecta";
                    password.Text = "";
                }
                else
                {
                    if(user.privilegio == 2)
                    {
                        Session.Add(Session.SessionID + "admin", user);
                        Response.Redirect("principalAdmin.aspx");
                    }
                    else
                    {
                        Session.Add(Session.SessionID + "usuario", user);
                        Response.Redirect("home.aspx");
                    }
                    
                }
            }
            else
            {
                validation.InnerText = "Usuario inexistente";
                validation.Attributes["class"] = "visible alert alert-danger";
            }
        }
    }
}
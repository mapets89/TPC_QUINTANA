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
    public partial class agregardomicilio : System.Web.UI.Page
    {
        DireccionNegocio direccionNegocio = new DireccionNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        Usuario usuario = new Usuario();
        Direccion direccion = new Direccion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                usuario = (Usuario)Session[Session.SessionID + "usuario"];

            }
        }

        protected void botonAgregar_Click(object sender, EventArgs e)
        {
            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            direccion.calle = calleUsuario.Text;
            direccion.altura = Convert.ToInt32(alturaUsuario.Text);
            direccion.localidad = localidadUsuario.Text;
            direccion.provincia = provinciaUsuario.Text;
            direccion.descripcion = descripcionUsuario.Text;
            direccionNegocio.Agregar(direccion);
            int idDireccion = direccionNegocio.BuscarDireccion();
            usuario.direccion.id = idDireccion;
            usuario.direccion.calle = calleUsuario.Text;
            usuario.direccion.altura = Convert.ToInt32(alturaUsuario.Text);
            usuario.direccion.localidad = localidadUsuario.Text;
            usuario.direccion.provincia = provinciaUsuario.Text;
            usuario.direccion.descripcion = descripcionUsuario.Text;
            usuarioNegocio.Modificar(usuario);
            Session.Add(Session.SessionID + "usuario", usuario);
            Response.Redirect("Carrito.aspx");
        }
    }
}
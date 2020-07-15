using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_QUINTANA
{
    public partial class detalleusuarios : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        DireccionNegocio direccionNegocio = new DireccionNegocio();
        Usuario usuario = new Usuario();
        Direccion direccion = new Direccion();
        List<Direccion> direccionList = new List<Direccion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "usuarioModif"] != null)
            {
                usuario = (Usuario)Session[Session.SessionID + "usuarioModif"];
                
                nombre.Text = usuario.nombre;
                apellido.Text = usuario.apellido;
                dni.Text = usuario.dni.ToString();
                username.Text = usuario.userName;
                contraseña.Text = usuario.password;
                privilegio.Text = usuario.privilegio.ToString();
                email.Text = usuario.email;
                calle.Text = usuario.direccion.calle;
                altura.Text = usuario.direccion.altura.ToString();
                localidad.Text = usuario.direccion.localidad;
                provincia.Text = usuario.direccion.provincia;
                descripcion.Text = usuario.direccion.descripcion;
            }

        }

        protected void botonDetalleUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
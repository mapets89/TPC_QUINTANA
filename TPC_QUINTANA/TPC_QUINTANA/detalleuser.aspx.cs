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
    public partial class detalleuser : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        DireccionNegocio direccionNegocio = new DireccionNegocio();
        Usuario usuario = new Usuario();
        Direccion direccion = new Direccion();
        List<Direccion> direccionList = new List<Direccion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Session.SessionID + "usuario"] != null)
                {
                    usuario = (Usuario)Session[Session.SessionID + "usuario"];
                    nombre.Text = usuario.nombre;
                    apellido.Text = usuario.apellido;
                    dni.Text = usuario.dni.ToString();
                    username.Text = usuario.userName;
                    contraseña.Text = usuario.password;
                    email.Text = usuario.email;
                    calle.Text = usuario.direccion.calle;
                    altura.Text = usuario.direccion.altura.ToString();
                    localidad.Text = usuario.direccion.localidad;
                    provincia.Text = usuario.direccion.provincia;
                    descripcion.Text = usuario.direccion.descripcion;
                }

            }

        }
        protected void botonDetalleUsuario_Click(object sender, EventArgs e)
        {
            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            usuario.nombre = nombre.Text;
            usuario.apellido = apellido.Text;
            usuario.dni = Convert.ToInt32(dni.Text);
            usuario.userName = username.Text;
            usuario.password = contraseña.Text;
            direccion.calle = calle.Text;
            direccion.altura = Convert.ToInt32(altura.Text);
            direccion.localidad = localidad.Text;
            direccion.provincia = provincia.Text;
            direccion.descripcion = descripcion.Text;
            if (usuario.direccion.id == 1)
            {
                direccionNegocio.Agregar(direccion);
                int idDireccion = direccionNegocio.BuscarDireccion();
                usuario.direccion.id = idDireccion;
                usuarioNegocio.Modificar(usuario);
            }
            else
            {
                usuarioNegocio.Modificar(usuario);
                direccionNegocio.Modificar(direccion);

            }
            Session.Add(Session.SessionID + "usuario", usuario);
        }
    }
}
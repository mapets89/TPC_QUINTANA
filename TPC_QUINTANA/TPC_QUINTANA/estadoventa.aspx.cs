using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_QUINTANA
{
    public partial class estadoventa : System.Web.UI.Page
    {
        Ventacs venta = new Ventacs();
        VentaNegocio ventaNegocio = new VentaNegocio();
        Usuario usuario = new Usuario();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    venta = (Ventacs)Session[Session.SessionID + "venta"];
                    ddlEstadoVenta.Items.Add("Seleccione el estado de la venta");
                    ddlEstadoVenta.AppendDataBoundItems = true;
                    ddlEstadoVenta.Items.Add("Pendiente de Pago");
                    ddlEstadoVenta.Items.Add("Envio en curso");
                    ddlEstadoVenta.Items.Add("Transaccion Completa");
                    ddlEstadoVenta.BackColor = System.Drawing.Color.Transparent;
                    ddlEstadoVenta.BorderColor = System.Drawing.Color.Transparent;
                    ddlEstadoVenta.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Cambiar_Click(object sender, EventArgs e)
        {
            venta = (Ventacs)Session[Session.SessionID + "venta"];
            ventaNegocio.Modificar(venta.estado, venta.idVenta);
            SmtpClient smtp = (SmtpClient)Session[Session.SessionID + "smtp"];
            MailMessage email = (MailMessage)Session[Session.SessionID + "email"];
            usuario.id = venta.idUsuario;
            usuarioNegocio.DetalleUsuario(usuario);
            email.To.Add(new MailAddress(usuario.email));
            email.Subject = "EN CASA - Cambio de estado de la Compra";
            email.Body = "Hola " + usuario.nombre + ", queremos comentarte que tu compra cambio de estado, conectate para realizar el seguimiento" +
                "de la compra https://localhost:44303/login";
            smtp.Send(email);
            email.Dispose();
            Response.Redirect("ventas.aspx");
        }

        protected void ddlEstadoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            venta = (Ventacs)Session[Session.SessionID + "venta"];
            switch(ddlEstadoVenta.Text)
            {
                case "Pendiente de Pago":
                    {
                        venta.estado = 0;
                        break;
                    }
                case "Envio en curso":
                    {
                        venta.estado = 1;
                        break;
                    }
                case "Transaccion Completa":
                    {
                        venta.estado = 2;
                        break;
                    }
            }
            Session.Add(Session.SessionID + "venta", venta);
        }
    }
}
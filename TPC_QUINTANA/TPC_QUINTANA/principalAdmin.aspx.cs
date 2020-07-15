using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("matiasquin@gmail.com", "4702601230.");

                MailMessage email = new MailMessage();
                email.From = new MailAddress("matiasquin@gmail.com");
                email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.Body = "Cualquier contenido en <b>HTML</b> para enviarlo por correo electrónico.";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                Session.Add(Session.SessionID + "email", email);
                Session.Add(Session.SessionID + "smtp", smtp);

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
            int id = Convert.ToInt32(e.CommandArgument);
            foreach (Articulo item in ArticulosList)
            {
                if (item.id == id)
                {
                    Session.Add(Session.SessionID + "modificar", item);
                    break;
                }
            }
            Response.Redirect("articuloDetalle.aspx");
        }

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                foreach (Articulo item in ArticulosList)
                {
                    item.existencia = 0;
                    negocio.Eliminar(item);
                    break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
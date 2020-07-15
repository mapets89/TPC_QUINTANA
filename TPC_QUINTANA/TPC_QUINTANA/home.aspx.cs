using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_QUINTANA
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[Session.SessionID + "usuario"] != null)
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

            }
        }
    }
}
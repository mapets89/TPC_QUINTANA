using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_QUINTANA
{
    public partial class compras : System.Web.UI.Page
    {
        VentaNegocio ventaNegocio = new VentaNegocio();
        Usuario usuario = new Usuario();
        List<Ventacs> ventaList = new List<Ventacs>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            int indexEstado = 0;
            int cont = 0;
            if (!IsPostBack)
            {

                ventaList = ventaNegocio.TraerVenta(usuario.id);

                dgvCompras.DataSource = ventaList;
                dgvCompras.DataBind();
                foreach(var item in ventaList)
                {
                    cont++;
                }
                while (indexEstado < cont)
                {

                    switch (dgvCompras.Rows[indexEstado].Cells[4].Text)
                    {
                        case "0":
                            {
                                dgvCompras.Rows[indexEstado].Cells[4].Text = "Pendiente de Pago";
                                break;
                            }
                        case "1":
                            {
                                dgvCompras.Rows[indexEstado].Cells[4].Text = "Envio en Curso";
                                break;
                            }
                        case "2":
                            {
                                dgvCompras.Rows[indexEstado].Cells[4].Text = "Transaccion Completa";
                                break;
                            }
                    }
                    indexEstado++;
                }
            }
        }

        protected void dgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int idVenta = Convert.ToInt32(dgvCompras.Rows[index].Cells[1].Text);
            Session.Add(Session.SessionID + "venta", idVenta);
            Response.Redirect("detalleVenta.aspx");
        }
    }
}
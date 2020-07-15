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
    public partial class ventas : System.Web.UI.Page
    {
        List<Ventacs> ventasList = new List<Ventacs>();
        List<Ventacs> listaFiltrada = new List<Ventacs>();
        VentaNegocio ventaNegocio = new VentaNegocio();
        List<string> usuariosList = new List<string>();
        Ventacs venta = new Ventacs();
        string aux;
        int indexEstado = 0;
        int cont = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ventasList = ventaNegocio.ListarVentas();
                if (!IsPostBack)
                {
                    dgvVentas.DataSource = ventasList;
                    dgvVentas.DataBind();
                    foreach (var user in ventasList)
                    {
                        if (aux != user.nombreUsuario)
                        {
                            aux = user.nombreUsuario;
                            if (!(usuariosList.Exists(k => k == aux)))
                            {
                                usuariosList.Add(aux);

                            }

                        }
                    }
                    ddlUsuario.Items.Add("--- Filtra por Username ---");
                    ddlUsuario.AppendDataBoundItems = true;
                    ddlUsuario.DataSource = usuariosList;
                    ddlUsuario.DataBind();
                    ddlEstado.Items.Add("--- Filtrar por Estado ---");
                    ddlEstado.AppendDataBoundItems = true;
                    ddlEstado.Items.Add("Pendiente de Pago");
                    ddlEstado.Items.Add("Envio en Curso");
                    ddlEstado.Items.Add("Transaccion Completa");
                    ddlEstado.DataBind();
                    foreach (var item in ventasList)
                    {
                        cont++;
                    }
                    while (indexEstado < cont)
                    {

                        switch (dgvVentas.Rows[indexEstado].Cells[5].Text)
                        {
                            case "0":
                                {
                                    dgvVentas.Rows[indexEstado].Cells[5].Text = "Pendiente de Pago";
                                    break;
                                }
                            case "1":
                                {
                                    dgvVentas.Rows[indexEstado].Cells[5].Text = "Envio en Curso";
                                    break;
                                }
                            case "2":
                                {
                                    dgvVentas.Rows[indexEstado].Cells[5].Text = "Transaccion Completa";
                                    break;
                                }
                        }
                        indexEstado++;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idventa = Convert.ToInt32(dgvVentas.Rows[index].Cells[1].Text);
                venta = ventasList.Find(V => V.idVenta == idventa);
                Session.Add(Session.SessionID + "venta", venta);
                Response.Redirect("estadoventa.aspx");
            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaFiltrada = ventasList.FindAll(v => v.nombreUsuario == ddlUsuario.Text);
            dgvVentas.DataSource = listaFiltrada;
            dgvVentas.DataBind();
            foreach (var item in listaFiltrada)
            {
                cont++;
            }
            while (indexEstado < cont)
            {

                switch (dgvVentas.Rows[indexEstado].Cells[5].Text)
                {
                    case "0":
                        {
                            dgvVentas.Rows[indexEstado].Cells[5].Text = "Pendiente de Pago";
                            break;
                        }
                    case "1":
                        {
                            dgvVentas.Rows[indexEstado].Cells[5].Text = "Envio en Curso";
                            break;
                        }
                    case "2":
                        {
                            dgvVentas.Rows[indexEstado].Cells[5].Text = "Transaccion Completa";
                            break;
                        }
                }
                indexEstado++;
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlEstado.Text)
            {
                case "Pendiente de Pago":
                    {
                        listaFiltrada = ventasList.FindAll(v => v.estado == 0);
                        break;
                    }
                case "Envio en Curso":
                    {
                        listaFiltrada = ventasList.FindAll(v => v.estado == 1);
                        break;
                    }
                case "Transaccion Completa":
                    {
                        listaFiltrada = ventasList.FindAll(v => v.estado == 2);
                        break;
                    }
            }
            dgvVentas.DataSource = listaFiltrada;
            dgvVentas.DataBind();
            foreach (var item in listaFiltrada)
            {
                cont++;
            }
            while (indexEstado < cont)
            {

                switch (dgvVentas.Rows[indexEstado].Cells[5].Text)
                {
                    case "0":
                        {
                            dgvVentas.Rows[indexEstado].Cells[5].Text = "Pendiente de Pago";
                            break;
                        }
                    case "1":
                        {
                            dgvVentas.Rows[indexEstado].Cells[5].Text = "Envio en Curso";
                            break;
                        }
                    case "2":
                        {
                            dgvVentas.Rows[indexEstado].Cells[5].Text = "Transaccion Completa";
                            break;
                        }
                }
                indexEstado++;
            }

        }
    }
}
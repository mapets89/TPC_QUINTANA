using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using Dominio;
using Negocio;
namespace TPC_QUINTANA
{
    public partial class Carrito : System.Web.UI.Page
    {
        List<Articulo> listaArticulo1 = new List<Articulo>();
        Carro carrito = new Carro();
        Usuario usuario = new Usuario();
        Ventacs venta = new Ventacs();
        VentaNegocio ventaNegocio = new VentaNegocio();
        VentaxUsuario ventaArticulo = new VentaxUsuario();
        VentaXArticuloNegocio ventaArticuloNegocio = new VentaXArticuloNegocio();
        ArticuloNegocio negocio = new ArticuloNegocio();
        bool compro = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            Articulo articulo = new Articulo();
            System.Globalization.CultureInfo culture;
            try
            {
                if (Session[Session.SessionID + "articulo"] != null)
                {
                    carrito = (Carro)Session[Session.SessionID + "articulo"];
                    string specifier = "N";
                    culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES");
                    if (carrito.precioTotal != 0)
                    {
                        totalLabel.Text = "TOTAL   $ " + carrito.precioTotal.ToString(specifier, culture);
                        comprar.Visible = true;
                    }
                    else
                    {
                        if (Session[Session.SessionID + "compro"] == null || compro == false)
                        {
                            totalLabel.Text = "Ups parace que todavia no agregaste nada al carrito...";
                            totalLabel.CssClass = "sinItems";
                            comprar.Visible = false;
                        }
                        else
                        {
                            totalLabel.Text = "Muchas gracias por tu compra, te llegara un mail para realizar el pago de la misma";
                            totalLabel.CssClass = "sinItems";
                            comprar.Text = "Volver";
                            Session.Remove(Session.SessionID + "compro");
                        }

                    }
                    dgvCarritoCompras.DataSource = carrito.carro;
                    dgvCarritoCompras.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void dgvCarritoCompras_RowCommand(object sender, GridViewCommandEventArgs gridViewEvent)
        {
            int index = Convert.ToInt32(gridViewEvent.CommandArgument);
            int idArticulo = Convert.ToInt32(dgvCarritoCompras.Rows[index].Cells[1].Text);
            Articulo articulo = carrito.carro.Find(A => A.id == idArticulo);
            if (Session[Session.SessionID + "precio"] == null || articulo.id != (int)Session[Session.SessionID + "idSelec"])
            {
                articulo.precio /= articulo.cantidad;
                Session.Add(Session.SessionID + "precio", articulo.precio);
                Session.Add(Session.SessionID + "idSelec", articulo.id);
            }
            decimal precioAux = (decimal)Session[Session.SessionID + "precio"];
            switch (gridViewEvent.CommandName)
            {
                case "Eliminar":

                    carrito.carro.Remove(articulo);
                    carrito.cantArt--;
                    carrito.precioTotal -= precioAux * articulo.cantidad;
                    Session.Add(Session.SessionID + "articulo", carrito);
                    break;
                case "Add":
                    if (articulo.cantidad + 1 <= articulo.stock)
                    {
                        articulo.cantidad++;
                        carrito.precioTotal += precioAux;
                        articulo.precio = articulo.cantidad * precioAux;
                    }
                    break;
                case "Rest":
                    if (articulo.cantidad > 1)
                    {
                        articulo.cantidad--;
                        articulo.precio = precioAux * articulo.cantidad;
                        carrito.precioTotal -= precioAux;
                    }
                    break;
            }

            Response.Redirect("Carrito.aspx");
        }

        protected void btnArgumento_Command(object sender, CommandEventArgs e)
        {

        }

        protected void comprar_Click(object sender, EventArgs e)
        {
            if (comprar.Text == "Volver")
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                if (Session[Session.SessionID + "usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                usuario = (Usuario)Session[Session.SessionID + "usuario"];
                if (usuario.direccion.id == 1)
                {
                    Response.Redirect("agregardomicilio.aspx");
                }
                else
                {
                    SmtpClient smtp = (SmtpClient)Session[Session.SessionID + "smtp"];
                    MailMessage email = (MailMessage)Session[Session.SessionID + "email"];
                    bool compro = true;
                    venta.idUsuario = usuario.id;
                    venta.precioTotal = carrito.precioTotal;
                    venta.fecha = DateTime.Now.Date;
                    ventaNegocio.Agregar(venta);
                    venta.idVenta = ventaNegocio.BuscarVenta();
                    foreach (var item in carrito.carro)
                    {
                        ventaArticulo.idArticulo = item.id;
                        ventaArticulo.idVenta = venta.idVenta;
                        ventaArticulo.cantidad = item.cantidad;
                        ventaArticulo.money = item.precio / item.cantidad;
                        ventaArticuloNegocio.Agregar(ventaArticulo);
                        negocio.Venta(item.id, item.cantidad);
                    }
                    carrito.carro.Clear();
                    carrito.cantArt = 0;
                    carrito.precioTotal = 0;
                    Session.Add(Session.SessionID + "articulo", carrito);
                    Session.Add(Session.SessionID + "compro", compro);
                    email.To.Add (new MailAddress("matiasquin@gmail.com"));
                    email.Body = "El usuario <b>" + usuario.userName + "</b> realizo una compra";
                    email.Subject = "NUEVA COMPRA";
                    smtp.Send(email);
                    email.To.Add(new MailAddress(usuario.email));
                    email.Subject = "EN CASA - Compra realizada el" + DateTime.Now.ToString("dd / MMM / yyy hh: mm: ss");
                    email.Body = "Envio el Link de Pago por la compra realizada <b>link de pago</b>";
                    smtp.Send(email);
                    email.Dispose();
                    Response.Redirect("Carrito.aspx");
                }
            }
        }
    }

}

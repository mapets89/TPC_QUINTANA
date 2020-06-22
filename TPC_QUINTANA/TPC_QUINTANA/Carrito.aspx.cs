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
    public partial class Carrito : System.Web.UI.Page
    {
        List<Articulo> listaArticulo1 = new List<Articulo>();
        Carro carrito = new Carro();
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
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
                        totalLabel.Text = "TOTAL   $ " + carrito.precioTotal.ToString(specifier, culture);
                    else
                    {
                        totalLabel.Text = "Ups parace que todavia no agregaste nada al carrito...";
                        totalLabel.CssClass = "sinItems";
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
                    articulo.cantidad++;
                    carrito.precioTotal += precioAux;
                    articulo.precio = articulo.cantidad * precioAux;
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
    }

}

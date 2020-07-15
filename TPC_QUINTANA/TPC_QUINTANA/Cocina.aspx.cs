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
    public partial class Cocina : System.Web.UI.Page
    {
        public List<Articulo> CocinaList { get; set; }
        public List<Articulo> ListaFiltrada = new List<Articulo>();
        protected Carousel carousel = new Carousel();
        protected CarouselNegocio carouselNegocio = new CarouselNegocio();
        protected ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                carousel.carousel = carouselNegocio.cargarCarousel();
                CocinaList = negocio.ListarCocina();
                if (!IsPostBack)
                {
                    imageCarousel1.ImageUrl = carousel.carousel[0].imagen;
                    nombreCarousel1.Text = carousel.carousel[0].nombre;
                    descripCarousel1.Text = carousel.carousel[0].descripcion;
                    precioCarousel1.Text = carousel.carousel[0].precio.ToString();
                    imageCarousel2.ImageUrl = carousel.carousel[1].imagen;
                    nombreCarousel2.Text = carousel.carousel[1].nombre;
                    descripCarousel2.Text = carousel.carousel[1].descripcion;
                    precioCarousel2.Text = carousel.carousel[1].precio.ToString();
                    imageCarousel3.ImageUrl = carousel.carousel[2].imagen;
                    nombreCarousel3.Text = carousel.carousel[2].nombre;
                    descripCarousel3.Text = carousel.carousel[2].descripcion;
                    precioCarousel3.Text = carousel.carousel[2].precio.ToString();
                    Repeater.DataSource = CocinaList;
                    Repeater.DataBind();
                }
                else
                {
                    if (Session[Session.SessionID + "busqueda"] != null)
                    {
                        string busqueda = (string)Session[Session.SessionID + "busqueda"];
                        ListaFiltrada = CocinaList.FindAll(A => A.nombre.ToLower().Contains(busqueda.ToLower()));
                        Repeater.DataSource = ListaFiltrada;
                        Repeater.DataBind();
                    }
                    else
                    {
                        Repeater.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void addCarrito_Command(object sender, CommandEventArgs e)
        {
            Carro carro = new Carro();
            Articulo articulo = new Articulo();
            try
            {
                var articuloSelec = Convert.ToInt32(((Button)sender).CommandArgument);
                articulo = CocinaList.Find(J => J.id == articuloSelec);
                if (articulo.enStock != "Producto sin Stock")
                {
                    if (Session[Session.SessionID + "articulo"] != null)
                    {
                        carro = (Carro)Session[Session.SessionID + "articulo"];
                    }
                    if (!carro.carro.Exists(A => A.id == articulo.id))
                    {
                        carro.carro.Add(articulo);
                        carro.cantArt++;
                        carro.precioTotal += articulo.precio;
                        Session.Add(Session.SessionID + "articulo", carro);
                    }
                    Response.Redirect("Cocina.aspx");
                }
                else
                {
                    Response.Redirect("Cocina.aspx");
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
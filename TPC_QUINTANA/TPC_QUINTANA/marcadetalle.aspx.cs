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
    public partial class marcadetalle : System.Web.UI.Page
    {
        MarcaNegocio marcaNegocio = new MarcaNegocio();
        Marca marca;
        string nombreMarca;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "marcaAdmin"] != null)
            {
                marca = (Marca)Session[Session.SessionID + "marcaAdmin"];
                marcaLabel.Attributes["placeholder"] = marca.nombre;
                Agregar.Text = "Modificar";
                title.Text = "Cambie el nombre a la Marca";
            }
            else
            {
                marcaLabel.Attributes["placeholder"] = "Ingresa el nombre de la Marca";

            }

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            if (Agregar.Text == "Modificar")
            {
                marca.nombre = marcaLabel.Text;
                marcaNegocio.Modificar(marca);
            }
            else
            {
                nombreMarca = marcaLabel.Text;
                marcaNegocio.AgregarMarca(nombreMarca);
            }
            Response.Redirect("marcas.aspx");
        }
    }
}
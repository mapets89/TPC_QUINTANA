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
    public partial class categoriadetalle : System.Web.UI.Page
    {
        CategoriaNegocio negocioCategoria = new CategoriaNegocio();
        Categoria categoria;
        string nombreCategoria;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "categoriaAdmin"] != null)
            {
                categoria = (Categoria)Session[Session.SessionID + "categoriaAdmin"];
                categoriaLabel.Attributes["placeholder"] = categoria.nombre;
                Agregar.Text = "Modificar";
                title.Text = "Cambie el nombre a la Marca";
            }
            else
            {
                categoriaLabel.Attributes["placeholder"] = "Ingresa el nombre de la Categoria";

            }

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            if (Agregar.Text == "Modificar")
            {
                categoria.nombre = categoriaLabel.Text;
                negocioCategoria.Modificar(categoria);
            }
            else
            {
                nombreCategoria = categoriaLabel.Text;
                negocioCategoria.Agregar(nombreCategoria);
            }
            Response.Redirect("categorias.aspx");
        }
    }
}
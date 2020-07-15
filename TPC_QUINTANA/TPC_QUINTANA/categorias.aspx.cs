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
    public partial class categorias : System.Web.UI.Page
    {
        protected CategoriaNegocio negocioCategoria = new CategoriaNegocio();
        public List<Categoria> CategoriasList { get; set; }
        public Categoria categoria;
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriasList = negocioCategoria.ListarCategorias();
            try
            {
                if (!IsPostBack)
                {
                    dgvCategorias.DataSource = CategoriasList;
                    dgvCategorias.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("categoriadetalle.aspx");
        }

        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int idSelec = Convert.ToInt32(dgvCategorias.Rows[index].Cells[1].Text);
            categoria = CategoriasList.Find(k => k.id == idSelec);
            switch (e.CommandName)
            {
                case "Eliminar":
                    negocioCategoria.Eliminar(categoria);
                    Response.Redirect("categorias.aspx");
                    break;
                case "Modificar":
                    Session.Add(Session.SessionID + "categoriaAdmin", categoria);
                    Response.Redirect("categoriadetalle.aspx");
                    break;
            }

        }
    
    }
}
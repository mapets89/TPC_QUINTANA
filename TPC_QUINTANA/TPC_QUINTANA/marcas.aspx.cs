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
    public partial class marcas : System.Web.UI.Page
    {
        protected MarcaNegocio negocioMarca = new MarcaNegocio();
        public List<Marca> MarcasList { get; set; }
        public Marca marca;
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcasList = negocioMarca.ListarMarcas();
            try
            {
                if (!IsPostBack)
                {
                    dgvMarcas.DataSource = MarcasList;
                    dgvMarcas.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int idSelec = Convert.ToInt32(dgvMarcas.Rows[index].Cells[1].Text);
            marca = MarcasList.Find(k => k.id == idSelec);
            switch (e.CommandName)
            {
                case "Eliminar":
                    negocioMarca.Eliminar(marca);
                    Response.Redirect("marcas.aspx");
                    break;
                case "Modificar":
                    Session.Add(Session.SessionID + "marcaAdmin", marca);
                    Response.Redirect("marcadetalle.aspx");
                    break;
            }

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("marcadetalle.aspx");
        }
    }
}
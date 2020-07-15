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
    public partial class usuariosadmin : System.Web.UI.Page
    {
        protected UsuarioNegocio negocioUsuario = new UsuarioNegocio();
        public List<Usuario> UsuarioList { get; set; }
        protected Usuario usuario = new Usuario();
        protected Direccion direccion = new Direccion();
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioList = negocioUsuario.Listar();
            try
            {
                if (!IsPostBack)
                {
                    dgvUsuarios.DataSource = UsuarioList;
                    dgvUsuarios.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int idSelec = Convert.ToInt32(dgvUsuarios.Rows[index].Cells[1].Text);
            switch (e.CommandName)
            {
                case "Modificar":
                    foreach (Usuario item in UsuarioList)
                    {
                        if (item.id == idSelec)
                        {
                            Session.Add(Session.SessionID + "usuarioModif", item);
                            break;
                        }
                    }
                    Response.Redirect("detalleusuarios.aspx");
                    break;
            }
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleusuarios.aspx");
        }
    }
}

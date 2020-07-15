using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_QUINTANA
{
    public partial class proveedoresList : System.Web.UI.Page
    {
        protected ProveedorNegocio negocioProveedor = new ProveedorNegocio();
        public List<Proveedor> ProveedorList { get; set; }
        protected Proveedor proveedor = new Proveedor();
        protected Direccion direccion = new Direccion();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorList = negocioProveedor.ListarProveedores();
            try
            {
                if (!IsPostBack)
                {
                    dgvProveedores.DataSource = ProveedorList;
                    dgvProveedores.DataBind();
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
            int idSelec = Convert.ToInt32(dgvProveedores.Rows[index].Cells[1].Text);
            switch (e.CommandName)
            {
                case "Modificar":
                    foreach (Proveedor item in ProveedorList)
                    {
                        if (item.cod == idSelec)
                        {
                            Session.Add(Session.SessionID + "proveedorModif", item);
                            break;
                        }
                    }
                    Response.Redirect("proveedorDetalle.aspx"); 
                    break;
                case "Eliminar":
                    foreach (Proveedor item in ProveedorList)
                    {
                        if (item.cod == idSelec)
                        {
                            item.existencia = 0;
                            negocioProveedor.Eliminar(item);
                            break;
                        }
                    }
                    Response.Redirect("proveedoresList.aspx");
                    break;
            }
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("proveedorDetalle.aspx");
        }
    }
}
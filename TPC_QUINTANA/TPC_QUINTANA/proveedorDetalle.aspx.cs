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
    public partial class proveedorDetalle : System.Web.UI.Page
    {
        protected Proveedor proveedor = new Proveedor();
        protected ProveedorNegocio negocioProveedor = new ProveedorNegocio();
        protected Direccion direccion = new Direccion();
        protected DireccionNegocio direccionNegocio = new DireccionNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session[Session.SessionID + "proveedorModif"] != null)
                {
                    if (!IsPostBack)
                    {
                        proveedor = (Proveedor)Session[Session.SessionID + "proveedorModif"];
                        nombreProv.Text = proveedor.nombre;
                        descripProv.Text = proveedor.descripcion;
                        calleProv.Text = proveedor.direccion.calle;
                        alturaProv.Text = proveedor.direccion.altura.ToString();
                        provinciaProv.Text = proveedor.direccion.provincia;
                        localidadProv.Text = proveedor.direccion.localidad;
                    }

                }
                else
                {
                    Session.Add(Session.SessionID + "proveedorModif", proveedor);
                    nombreProv.Attributes.Add("placeholder", "Ingrese el nombre del proveedor");
                    descripProv.Attributes.Add("placeholder", "Ingrese la descripcion del proveedor");
                    calleProv.Attributes.Add("placeholder", "Ingrese la calle del proveedor");
                    alturaProv.Attributes.Add("placeholder", "Ingrese la altura");
                    provinciaProv.Attributes.Add("placeholder", "Ingrese la Provincia");
                    localidadProv.Attributes.Add("placeholder", "Ingrese la Localidad");
                    botonDetalleProveedor.Text = "AGREGAR";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void botonDetalleProveedor_Click(object sender, EventArgs e)
        {
            proveedor = (Proveedor)Session[Session.SessionID + "proveedorModif"];
            proveedor.nombre = nombreProv.Text;
            proveedor.descripcion = descripProv.Text;
            direccion.calle = calleProv.Text;
            direccion.altura = Convert.ToInt32(alturaProv.Text);
            direccion.localidad = localidadProv.Text;
            direccion.provincia = provinciaProv.Text;
            if (botonDetalleProveedor.Text == "MODIFICAR")
            {
                negocioProveedor.Modificar(proveedor);
                direccion.id = proveedor.direccion.id;
                direccionNegocio.Modificar(direccion);
            }
            else
            {
                direccionNegocio.Agregar(direccion);
                int idDireccion = direccionNegocio.BuscarDireccion();
                proveedor.direccion.id = idDireccion;
                negocioProveedor.Agregar(proveedor);
            }
        }
    }
}
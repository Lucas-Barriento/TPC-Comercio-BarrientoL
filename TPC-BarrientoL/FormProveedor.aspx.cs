using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)///si se envia un id en la direccion de la pagina 
            {
                if (!IsPostBack)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    ProveedorNegocio negocio = new ProveedorNegocio();
                    Proveedor seleccionado = negocio.Listar().Find(x => x.Id == id);//busca en la lista la coincidencia
                                                                                    //precargar los datos del id seleccionado
                    txtBoxId.Text = seleccionado.Id.ToString();
                    txtBoxId.ReadOnly = true;
                    txtBoxNombre.Text = seleccionado.Nombre.ToString();
                    txtBoxDomicilio.Text = seleccionado.Domicilio.ToString();
                    txtBoxLocalidad.Text = seleccionado.Localidad.ToString();
                    txtBoxEmail.Text = seleccionado.Email.ToString();
                    txtBoxTelefono.Text = seleccionado.Telefono.ToString();
                    if (seleccionado.Estado)
                    {
                        rbActivo.Checked = true;
                    }
                    else
                    {
                        rbInactivo.Checked = true;
                    }
                }
            }
            else
            {
                rbActivo.Checked = true;
            }
            lblId.Visible = false;
            txtBoxId.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            proveedor.Nombre = txtBoxNombre.Text;
            proveedor.Domicilio = txtBoxDomicilio.Text;
            proveedor.Localidad = txtBoxLocalidad.Text;
            proveedor.Email = txtBoxEmail.Text;
            proveedor.Telefono = txtBoxTelefono.Text;

            if (rbActivo.Checked)
            {
                proveedor.Estado = true;
            }
            else { proveedor.Estado = false; }

            if (Request.QueryString["Id"] != null)
            {
                proveedor.Id = int.Parse(txtBoxId.Text.ToString());
                proveedorNegocio.Modificar(proveedor);
            }
            else
            {
                proveedorNegocio.Agregar(proveedor);
            }
            Response.Redirect("Proveedor.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedor.aspx");
        }
    }
}
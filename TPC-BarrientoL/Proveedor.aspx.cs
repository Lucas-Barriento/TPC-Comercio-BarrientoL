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
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            dgvProveedores.DataSource = negocio.Listar();
            dgvProveedores.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProveedor.aspx");
        }
        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvProveedores.DataKeys[indice].Value.ToString());
            if (e.CommandName.ToString() == "Eliminar")//sino es Eliminar, es Modificar
            {
                //falta confirmacion de eliminar...
                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.Eliminar(id);
                Response.Redirect("Proveedor.aspx");
            }
            else
            {
                Response.Redirect("FormProveedor.aspx?id=" + id);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            dgvProveedores.DataSource = proveedorNegocio.Listar().FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            dgvProveedores.DataBind();
        }
    }
}
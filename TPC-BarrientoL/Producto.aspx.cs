using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.ListarProductos();
            dgvProductos.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProducto.aspx");
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvProductos.DataKeys[indice].Value.ToString());

            if (e.CommandName.ToString() == "Eliminar")//sino es Eliminar, es Modificar
            {
                //falta confirmacion de eliminar...
                ProductoNegocio negocio = new ProductoNegocio();
                negocio.Eliminar(id);
                Response.Redirect("Producto.aspx");
            }
            else
            {
                Response.Redirect("FormProducto.aspx?id=" + id);
            }
        }
    }
}
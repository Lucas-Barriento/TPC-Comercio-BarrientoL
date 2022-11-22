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
    public partial class FormCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.ListarProductos();
            dgvProductos.DataBind();

            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            List<Proveedor> listaProveedores = proveedorNegocio.Listar();
            ddlProveedor.DataSource = listaProveedores;
            ddlProveedor.DataValueField = "Id";
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataBind();
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //agregar producto a la compra
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvProductos.DataKeys[indice].Value.ToString());
            
            //funcion de agregar compra y sumar stock a la cantidad del producto, ver como usar proveedor


        }
    }
}
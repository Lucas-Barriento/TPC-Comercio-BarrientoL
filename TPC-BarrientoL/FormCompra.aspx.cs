using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormCompra : System.Web.UI.Page
    {
        public List<DetalleTransaccion> detalleTransaccionList = new List<DetalleTransaccion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            detalleTransaccionList = CompraSession();

            if (!IsPostBack)
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                List<Proveedor> listaProveedores = proveedorNegocio.Listar();
                ddlProveedor.DataSource = listaProveedores;
                ddlProveedor.DataValueField = "Id";
                ddlProveedor.DataTextField = "Nombre";
                ddlProveedor.DataBind();
                ddlProveedor.Items.Insert(0, new ListItem(""));
            }
        }
        public List<DetalleTransaccion> CompraSession()
        {
            List<DetalleTransaccion> listacompra = Session["ProductosCompra"] != null ? (List<DetalleTransaccion>)(Session["ProductosCompra"]) : new List<DetalleTransaccion>();
            return listacompra;
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //agregar producto a la compra
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvProductos.DataKeys[indice].Value.ToString());

            foreach (var item in detalleTransaccionList)
            {
                if (item.IdProducto==id)
                {
                        
                }
            }
            
            //funcion de agregar compra y sumar stock a la cantidad del producto, ver como usar proveedor
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (ddlProveedor.SelectedItem.Value != "" )
            {
                
                ProductoNegocio negocio = new ProductoNegocio();
                dgvProductos.DataSource = negocio.FiltrarProductosXProveedor(int.Parse(ddlProveedor.SelectedItem.Value.ToString()));
                dgvProductos.DataBind();
            }
            else
            {
                //vacia la grilla
                dgvProductos.DataSource=null;
                dgvProductos.DataBind();
            }
            
        }
    }
}
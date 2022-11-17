using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormVenta : System.Web.UI.Page
    {
        public List<DetalleTransaccion> listaDetalle { get; set; }
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

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaClientes = clienteNegocio.Listar();
            ddlCliente.DataSource = listaClientes;
            ddlCliente.DataValueField = "Id";
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataBind();

        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvProductos.DataKeys[indice].Value.ToString());
            
                //funcion de agregar venta, restar stock(validar) con Session
            }

    }
}
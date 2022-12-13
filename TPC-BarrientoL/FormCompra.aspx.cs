using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormCompra : System.Web.UI.Page
    {
        public List<DetalleTransaccion> detalleTransaccionList = new List<DetalleTransaccion>();
        public List<Producto> productos = new List<Producto>();
        public List<Proveedor> listaProveedores = new List<Proveedor>();
        public List<Proveedor_Producto> proveedor_Productos = new List<Proveedor_Producto>();
        ProductoNegocio productoNegocio = new ProductoNegocio();
        ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            productos = productoNegocio.ListarProductos().FindAll(x => x.Estado == true);
            detalleTransaccionList = CompraSession();

            if (!IsPostBack)
            {
                listaProveedores = proveedorNegocio.Listar().FindAll(x => x.Estado == true);
                ddlProveedor.DataSource = listaProveedores;
                ddlProveedor.DataValueField = "Id";
                ddlProveedor.DataTextField = "Nombre";
                ddlProveedor.DataBind();
                ddlProveedor.Items.Insert(0, new ListItem(""));
            }
            if (ddlProveedor.SelectedItem.Value != "")
            {
                ProductoNegocio negocio = new ProductoNegocio();
                dgvProductos.DataSource = negocio.FiltrarProductosXProveedor(int.Parse(ddlProveedor.SelectedItem.Value.ToString()));
                dgvProductos.DataBind();
            }
        }
        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            ////agregar producto a la compra
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvProductos.DataKeys[indice].Value.ToString());
            bool existente = false;

            foreach (var item in detalleTransaccionList)
            {
                if (item.producto.Id == id)//si ya esta agregado
                {
                    item.Cantidad++;
                    existente = true;
                }
            }
            if (!(existente))
            {
                DetalleTransaccion nuevo = new DetalleTransaccion();
                Producto seleccionado = productoNegocio.ListarProductos().Find(x => x.Id == id);
                nuevo.producto = new Producto();
                nuevo.producto.Id = seleccionado.Id;
                nuevo.Cantidad = 1;
                nuevo.PrecioParcial = seleccionado.Precio;
                detalleTransaccionList.Add(nuevo);
            }
            Session.Add("ProductosCompra", detalleTransaccionList);
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProveedor.SelectedItem.Value != "")
            {
                btnBorrarLista_Click(sender, e);
                ProductoNegocio negocio = new ProductoNegocio();
                dgvProductos.DataSource = negocio.FiltrarProductosXProveedor(int.Parse(ddlProveedor.SelectedItem.Value.ToString()));
                dgvProductos.DataBind();
            }
            else
            {
                //vacia la grilla
                dgvProductos.DataSource = null;
                dgvProductos.DataBind();
            }
        }

        public List<DetalleTransaccion> CompraSession()
        {
            List<DetalleTransaccion> listaCompra = Session["ProductosCompra"] != null ? (List<DetalleTransaccion>)(Session["ProductosCompra"]) : new List<DetalleTransaccion>();
            return listaCompra;
        }

        protected void btnBorrarLista_Click(object sender, EventArgs e)
        {
            detalleTransaccionList.Clear();
            Session.Add("ProductosCompra", detalleTransaccionList);
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            productos = productoNegocio.ListarProductos();

            //guardar compra
            Compra nuevo = new Compra();
            CompraNegocio compraNegocio = new CompraNegocio();
            nuevo.Proveedor = new Proveedor();
            nuevo.Proveedor.Id = int.Parse(ddlProveedor.SelectedItem.Value.ToString());
            nuevo.FechaCompra = DateTime.Now;

            detalleTransaccionList.ForEach(x => nuevo.PrecioTotal += (x.PrecioParcial * x.Cantidad));

            compraNegocio.Agregar(nuevo);
            DetalleTransactionNegocio detalleTransactionNegocio = new DetalleTransactionNegocio();
            //
            foreach (var item in detalleTransaccionList)
            {
                //guardar los items de la compra
                detalleTransactionNegocio.AgregarCompraConSP(item);

                //actualiza el stock de los productos
                Producto seleccionado = productoNegocio.ListarProductos().Find(x => x.Id == item.producto.Id);
                seleccionado.Stock += item.Cantidad;
                productoNegocio.Modificar(seleccionado);
            }
            //limpia la lista de compra
            btnBorrarLista_Click(sender, e);
            Response.Redirect("Compra.aspx", false);
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvProductos.SelectedDataKey.Value.ToString());
            bool existente = false;

            //funcion de agregar venta, restar stock(validar) con Session
            foreach (var item in detalleTransaccionList)
            {
                if (item.producto.Id == id)//si ya esta agregado
                {
                    item.Cantidad++;
                    existente = true;
                }
            }
            if (!(existente))
            {
                DetalleTransaccion nuevo = new DetalleTransaccion();
                Producto seleccionado = productoNegocio.ListarProductos().Find(x => x.Id == id);
                nuevo.producto = new Producto();
                nuevo.producto.Id = seleccionado.Id;
                nuevo.Cantidad = 1;
                nuevo.PrecioParcial = seleccionado.Precio;
                detalleTransaccionList.Add(nuevo);
            }
            Session.Add("ProductosCompra", detalleTransaccionList);
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataBind();
        }
    }
}
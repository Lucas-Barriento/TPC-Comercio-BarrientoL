using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormVenta : System.Web.UI.Page
    {
        public List<Producto> productos = new List<Producto>();
        ProductoNegocio productoNegocio = new ProductoNegocio();
        public List<DetalleTransaccion> listaDetalle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaClientes = clienteNegocio.Listar().FindAll(x => x.Estado == true);
            productos = productoNegocio.ListarProductos().FindAll(x => x.Estado == true);
            if (!IsPostBack)
            {
                listaClientes.ForEach(x => x.Nombre = x.Apellido + " " + x.Nombre);
                ddlCliente.DataSource = listaClientes;
                ddlCliente.DataValueField = "Id";
                ddlCliente.DataTextField = "Nombre";
                ddlCliente.DataBind();
                ddlCliente.Items.Insert(0, new ListItem(""));
            }
                listaDetalle = VentaSession();
            if (ddlCliente.SelectedItem.Value != "")
            {
                ProductoNegocio negocio = new ProductoNegocio();
                dgvProductos.DataSource = negocio.ListarProductos();
                dgvProductos.DataBind();
            }
        }

        public List<DetalleTransaccion> VentaSession()
        {
            List<DetalleTransaccion> listaVenta = Session["ProductosVenta"] != null ? (List<DetalleTransaccion>)(Session["ProductosVenta"]) : new List<DetalleTransaccion>();
            return listaVenta;
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCliente.SelectedItem.Value != "")
            {
                btnBorrarLista_Click(sender, e);
                dgvProductos.DataSource = productoNegocio.ListarProductos().FindAll(x => x.Estado == true);
                dgvProductos.DataBind();
            }
            else
            {
                //vacia la grilla
                dgvProductos.DataSource = null;
                dgvProductos.DataBind();
            }
        }

        protected void btnBorrarLista_Click(object sender, EventArgs e)
        {
            listaDetalle.Clear();
            Session.Add("productosVenta", listaDetalle);
        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            productos = productoNegocio.ListarProductos();

            Venta nuevo = new Venta();
            nuevo.FechaVenta = DateTime.Now;
            nuevo.cliente = new Cliente();
            nuevo.cliente.Id = int.Parse(ddlCliente.SelectedItem.Value.ToString());
            listaDetalle.ForEach(x => nuevo.PrecioTotal += x.PrecioParcial * x.Cantidad);

            VentaNegocio ventaNegocio = new VentaNegocio();
            ventaNegocio.Agregar(nuevo);

            DetalleTransactionNegocio detalleTransactionNegocio = new DetalleTransactionNegocio();
            foreach (var item in listaDetalle)
            {
                //guardar los items de la venta
                item.PrecioParcial = item.PrecioParcial * item.Cantidad;
                detalleTransactionNegocio.AgregarVentaConSP(item);
                //actualiza el stock de los productos
                Producto seleccionado = productoNegocio.ListarProductos().Find(x => x.Id == item.producto.Id);
                seleccionado.Stock -= item.Cantidad;
                productoNegocio.Modificar(seleccionado);
            }
            //limpia la lista de compra
            btnBorrarLista_Click(sender, e);
            Response.Redirect("Venta.aspx", false);
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataBind();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvProductos.SelectedDataKey.Value.ToString());
            bool existente = false;

            //funcion de agregar venta, restar stock(validar) con Session
            foreach (var item in listaDetalle)
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
                listaDetalle.Add(nuevo);
            }
            Session.Add("ProductosVenta", listaDetalle);
        }
    }
}
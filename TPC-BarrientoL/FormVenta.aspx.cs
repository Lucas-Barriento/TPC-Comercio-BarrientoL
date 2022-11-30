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
        public List<Producto> productos = new List<Producto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaClientes = clienteNegocio.Listar();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            productos = productoNegocio.ListarProductos();
            if (!IsPostBack)
            {

                ddlCliente.DataSource = listaClientes;
                ddlCliente.DataValueField = "Id";
                ddlCliente.DataTextField = "Apellido";
                ddlCliente.DataBind();
                ddlCliente.Items.Insert(0, new ListItem(""));
            }
            listaDetalle = VentaSession();


        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvProductos.DataKeys[indice].Value.ToString());
            ProductoNegocio productoNegocio = new ProductoNegocio();
            bool existente = false; 
            //funcion de agregar venta, restar stock(validar) con Session
            foreach (var item in listaDetalle)
            {
                if (item.IdProducto == id)//si ya esta agregado
                {
                    item.Cantidad++;
                    existente = true;
                }
            }
            if (!(existente))
            {
                DetalleTransaccion nuevo = new DetalleTransaccion();
                Producto seleccionado = productoNegocio.ListarProductos().Find(x => x.Id == id);
                nuevo.IdProducto = seleccionado.Id;
                nuevo.Cantidad = 1;
                nuevo.PrecioParcial = seleccionado.Precio;
                listaDetalle.Add(nuevo);
            }
            Session.Add("ProductosVenta", listaDetalle);
        }

        public List<DetalleTransaccion> VentaSession()
        {
            List<DetalleTransaccion> listaCompra = Session["ProductosVenta"] != null ? (List<DetalleTransaccion>)(Session["ProductosVenta"]) : new List<DetalleTransaccion>();
            return listaCompra;
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            
            if (ddlCliente.SelectedItem.Value!="")
            {
                dgvProductos.DataSource = productoNegocio.ListarProductos();
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
            ProductoNegocio productoNegocio = new ProductoNegocio();
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
                detalleTransactionNegocio.AgregarVentaConSP(item);
                //actualiza el stock de los productos
                Producto seleccionado = productoNegocio.ListarProductos().Find(x => x.Id == item.IdProducto);
                seleccionado.Stock-= item.Cantidad;
                productoNegocio.Modificar(seleccionado);

            }
            //limpia la lista de compra
            btnBorrarLista_Click(sender, e);
        }
    }
}
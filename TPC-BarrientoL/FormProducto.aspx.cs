using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //precarga de marcas y categorias
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> listaMarcas = marcaNegocio.Listar();
                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataBind();

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategorias = categoriaNegocio.Listar();
                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataBind();

                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                List<Proveedor> listaProveedores = proveedorNegocio.Listar();
                ddlProveedor.DataSource = listaProveedores;
                ddlProveedor.DataValueField = "Id";
                ddlProveedor.DataTextField = "Nombre";
                ddlProveedor.DataBind();
            }

            if (Request.QueryString["Id"] != null)//precarga los datos del seleccionado
            {
                if (!IsPostBack)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    Producto seleccionado = productoNegocio.ListarProductos().Find(x => x.Id == id);

                    txtBoxId.Text = seleccionado.Id.ToString();
                    txtBoxId.ReadOnly = true;
                    txtBoxNombre.Text = seleccionado.Nombre.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlProveedor.SelectedValue = seleccionado.Proveedor.Id.ToString();
                    txtBoxStock.Text = seleccionado.Stock.ToString();
                    txtBoxStockMinimo.Text = seleccionado.StockMinimo.ToString();
                    txtBoxGanancia.Text = seleccionado.PorcentajeGanancia.ToString();
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
                //si se agrega un nuevo producto se precargan los valores vacios

                ddlMarca.Items.Insert(0, new ListItem(""));//agrega el nuevo item vacio
                ddlCategoria.Items.Insert(0, new ListItem(""));
                ddlProveedor.Items.Insert(0, new ListItem(""));
                rbInactivo.Checked = false;
            }
            lblId.Visible = false;
            txtBoxId.Visible = false;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            producto.Nombre = txtBoxNombre.Text;

            producto.Marca = new Marca();
            producto.Marca.Id = int.Parse(ddlMarca.SelectedValue.ToString());

            producto.Categoria = new Categoria();
            producto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue.ToString());

            producto.Proveedor = new Proveedor();
            producto.Proveedor.Id = int.Parse(ddlProveedor.SelectedValue.ToString());

            producto.Stock = int.Parse(txtBoxStock.Text);
            producto.StockMinimo = int.Parse(txtBoxStockMinimo.Text);
            producto.PorcentajeGanancia = decimal.Parse(txtBoxGanancia.Text);
            if (rbActivo.Checked)
            {
                producto.Estado = true;
            }
            else { producto.Estado = false; }

            if (Request.QueryString["Id"] != null)
            {
                producto.Id = int.Parse(txtBoxId.Text);
                productoNegocio.Modificar(producto);
            }
            else
            {
                productoNegocio.Agregar(producto);
            }
            Response.Redirect("Producto.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }
    }
}
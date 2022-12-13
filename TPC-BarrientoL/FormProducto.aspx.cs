using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace TPC_BarrientoL
{
    public partial class FormProducto : System.Web.UI.Page
    {
        public List<Proveedor> listaProveedores;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //precarga de marcas y categorias
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> listaMarcas = marcaNegocio.Listar().FindAll(x=>x.Estado==true);
                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataBind();


                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategorias = categoriaNegocio.Listar().FindAll(x => x.Estado == true);
                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataBind();

                //precarga de proveedores
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                listaProveedores = proveedorNegocio.Listar().FindAll(x => x.Estado == true);
                listacheck.DataSource = listaProveedores;
                listacheck.DataValueField = "Id";
                listacheck.DataTextField = "Nombre";
                listacheck.DataBind();

                
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
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    Proveedor_productoNegocio proveedor_ProductoNegocio = new Proveedor_productoNegocio();
                    List<Proveedor_Producto> listaProveedor_Producto = proveedor_ProductoNegocio.Listar();
                    foreach (var aux in  listaProveedor_Producto)
                    {
                        if (aux.IdProducto == seleccionado.Id)//si el prod seleccionado esta en la lista de provProd lo tilda
                        {
                            listacheck.Items.FindByValue(aux.IdProveedor.ToString()).Selected = true;
                        }
                    }

                    txtBoxStock.Text = seleccionado.Stock.ToString();
                    txtBoxStockMinimo.Text = seleccionado.StockMinimo.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString();
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
                //ddlMarca.Items.Insert(0, new ListItem("Please select", "0"));//agrega el nuevo item vacio
                //ddlCategoria.Items.Insert(0, new ListItem("","0"));
                rbInactivo.Checked = false;
            }
            lblId.Visible = false;
            txtBoxId.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Proveedor_productoNegocio proveedor_ProductoNegocio = new Proveedor_productoNegocio();

            Producto producto = new Producto();
            producto.Nombre = txtBoxNombre.Text;

            producto.Marca = new Marca();
            producto.Marca.Id = int.Parse(ddlMarca.SelectedValue.ToString());

            producto.Categoria = new Categoria();
            producto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue.ToString());

            producto.Stock = int.Parse(txtBoxStock.Text);
            producto.StockMinimo = int.Parse(txtBoxStockMinimo.Text);
            producto.Precio = decimal.Parse(txtPrecio.Text);
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

                proveedor_ProductoNegocio.Eliminar((int.Parse(txtBoxId.Text)));//borra todos los proveedores asociados al producto
                foreach (ListItem item in listacheck.Items)
                {
                    if (item.Selected)
                    {
                        Proveedor_Producto proveedor_Producto = new Proveedor_Producto();
                        proveedor_Producto.IdProducto = int.Parse(txtBoxId.Text);
                        proveedor_Producto.IdProveedor = int.Parse(item.Value.ToString());
                        proveedor_ProductoNegocio.Agregar(proveedor_Producto);
                    }
                }
            }
            else
            {
                productoNegocio.Agregar(producto);
                foreach (ListItem item in listacheck.Items)
                {
                    if (item.Selected)
                    {
                        AccesoDatos datos = new AccesoDatos();
                        Proveedor_Producto proveedor_Producto = new Proveedor_Producto();
                        proveedor_Producto.IdProveedor = int.Parse(item.Value.ToString());
                        proveedor_ProductoNegocio.AgregarConSP(proveedor_Producto);
                    }
                }
            }
            Response.Redirect("Producto.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }
    }
}
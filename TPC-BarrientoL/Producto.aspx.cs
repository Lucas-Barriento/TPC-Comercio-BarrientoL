using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Resources;

namespace TPC_BarrientoL
{
    public partial class Productos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCampo.Items.Insert(0, new ListItem(""));
                ddlCriterio.Items.Insert(0, new ListItem(""));
            }

            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.ListarProductos();
            dgvProductos.DataBind();

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProducto.aspx");
        }
        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormProducto.aspx?id=" + id);
        }

        protected void checkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Enabled = !checkAvanzado.Checked;//desactiva txtBuscar si no esta tildado filtroAvanzado
        }


        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();   
            if (ddlCampo.SelectedItem.ToString()=="Marca")
            {
                MarcaNegocio negocio = new MarcaNegocio();
                List<Marca> marcas = negocio.Listar();
                ddlCriterio.DataSource = marcas;
                ddlCriterio.DataValueField = "Id";
                ddlCriterio.DataTextField = "Nombre";
                ddlCriterio.DataBind();
                btnBuscar.Enabled = true;

            }
            else if (ddlCampo.SelectedItem.ToString() == "Categoria")
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                List<Categoria> categorias = negocio.Listar();
                ddlCriterio.DataSource = categorias;
                ddlCriterio.DataValueField = "Id";
                ddlCriterio.DataTextField = "Nombre";
                ddlCriterio.DataBind();
                btnBuscar.Enabled = true;
            }
            else if (ddlCampo.SelectedItem.ToString()=="")
            {
                btnBuscar.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = ddlCampo.SelectedItem.Text;
            string criterio = ddlCriterio.SelectedItem.Text;
            string filtro = txtFiltroAvanzado.Text.ToUpper();
            List<Producto> listaFiltrada = new List<Producto>();
            if (ddlCampo == null)
            {
                campo = "";
            }
            if (ddlCriterio==null)
            {
                criterio = "";
            }
            ProductoNegocio negocio = new ProductoNegocio();

            if (campo=="Marca")
            {
                listaFiltrada = negocio.ListarProductos().FindAll(x => x.Marca.Nombre == criterio && x.Nombre.ToUpper().Contains(filtro));
                Session.Add("listaProductosFiltrada",listaFiltrada);
                dgvProductos.DataSource = Session["listaProductosFiltrada"];
                dgvProductos.DataBind();
            }
            else if (campo=="Categoria")
            {
                listaFiltrada = negocio.ListarProductos().FindAll(x => x.Categoria.Nombre == criterio && x.Nombre.ToUpper().Contains(filtro));
                Session.Add("listaProductosFiltrada", listaFiltrada);
                dgvProductos.DataSource = Session["listaProductosFiltrada"];
                dgvProductos.DataBind();
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listaFiltrada = new List<Producto>();

            ProductoNegocio productoNegocio = new ProductoNegocio();
            listaFiltrada = productoNegocio.ListarProductos().FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())
                                                                        || x.Marca.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())
                                                                        || x.Categoria.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            Session.Add("listaProductosFiltrada", listaFiltrada);
            dgvProductos.DataSource = Session["listaProductosFiltrada"];
            dgvProductos.DataBind();
        }


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroAvanzado.Text = "";
            ddlCampo.SelectedIndex= 0;
            ddlCriterio.Items.Clear();
            btnBuscar.Enabled = false;
            checkAvanzado.Checked = false;
            txtBuscar.Enabled = true;
            txtBuscar.Text = "";
            Page_Load(sender, e);
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //dgvProductos.PageIndex= e.NewPageIndex;
            //dgvProductos.DataBind();
            List<Producto> lista= new List<Producto>();
            List<Producto> listaFiltrada = (List<Producto>)Session["listaProductosFiltrada"];

            if (listaFiltrada is null)
            {
                dgvProductos.PageIndex= e.NewPageIndex;
                dgvProductos.DataBind();
            }
            else
            {
                dgvProductos.PageIndex = e.NewPageIndex;
                dgvProductos.DataSource= listaFiltrada;
                dgvProductos.DataBind();
            }
        }
    }
    
}
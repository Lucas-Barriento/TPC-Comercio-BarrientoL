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
    public partial class FormCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)///si se envia un id en la direccion de la pagina 
            {
                if (!IsPostBack)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria seleccionado = negocio.Listar().Find(x => x.Id == id);//busca en la lista la coincidencia
                                                                                //precargar los datos del id seleccionado
                    txtBoxId.Text = seleccionado.Id.ToString();
                    txtBoxId.ReadOnly = true;
                    txtBoxNombre.Text = seleccionado.Nombre.ToString();
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
                rbActivo.Checked = true;
            }

            lblId.Visible = false;
            txtBoxId.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            categoria.Nombre = txtBoxNombre.Text;

            if (rbActivo.Checked)
            {
                categoria.Estado = true;
            }
            else { categoria.Estado = false; }

            if (Request.QueryString["Id"] != null)
            {
                categoria.Id = int.Parse(txtBoxId.Text.ToString());
                categoriaNegocio.Modificar(categoria);
            }
            else
            {
                categoriaNegocio.Agregar(categoria);
            }

            Response.Redirect("Categoria.aspx");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categoria.aspx");
        }
    }
}
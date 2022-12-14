using dominio;
using negocio;
using System;

namespace TPC_BarrientoL
{
    public partial class FormMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)///si se envia un id en la direccion de la pagina 
            {
                if (!IsPostBack)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca seleccionado = negocio.Listar().Find(x => x.Id == id);//busca en la lista la coincidencia
                                                                                //precargar los datos del id seleccionado
                    txtBoxId.Text = seleccionado.Id.ToString();
                    txtBoxId.ReadOnly = true;
                    txtBoxNombre.Text = seleccionado.Nombre.ToString();
                    if (seleccionado.Estado)
                    {
                        rbActivo.Checked = true;                    }
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

            Marca marca = new Marca();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            marca.Nombre = txtBoxNombre.Text;
            
            if (rbActivo.Checked)
            {
                marca.Estado = true;
            }
            else { marca.Estado = false; }

            if (Request.QueryString["Id"] != null)
            {
                marca.Id = int.Parse(txtBoxId.Text.ToString());
                marcaNegocio.Modificar(marca);
            }
            else {
                marcaNegocio.Agregar(marca);
            }
            
            Response.Redirect("Marca.aspx");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marca.aspx");
        }
    }
}
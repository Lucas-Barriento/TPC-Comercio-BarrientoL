using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)///si se envia un id en la direccion de la pagina 
            {
                lblId.Visible = false;
                txtBoxId.Visible = false;
                if (!IsPostBack)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente seleccionado = negocio.Listar().Find(x => x.Id == id);//busca en la lista la coincidencia
                                                                                //precargar los datos del id seleccionado
                    txtBoxId.Text = seleccionado.Id.ToString();
                    txtBoxId.ReadOnly = true;
                    txtBoxNombre.Text = seleccionado.Nombre.ToString();
                    txtBoxApellido.Text = seleccionado.Apellido.ToString();
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

            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            cliente.Id = int.Parse(txtBoxId.Text);
            cliente.Nombre = txtBoxNombre.Text;
            cliente.Apellido = txtBoxApellido.Text;
            if (rbActivo.Checked)
            {
                cliente.Estado = true;
            }
            else { cliente.Estado = false;  }

            if (Request.QueryString["Id"] != null)//si no se envia un link es porque se va a agregar
            {
                
                clienteNegocio.Modificar(cliente);
            }
            else
            {
                clienteNegocio.Agregar(cliente);
            }
            Response.Redirect("Cliente.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
    }
}
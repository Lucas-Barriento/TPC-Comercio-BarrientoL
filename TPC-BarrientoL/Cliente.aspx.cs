using negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.Listar();
            dgvClientes.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCliente.aspx");
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvClientes.DataKeys[indice].Value.ToString());

            if (e.CommandName.ToString() == "Eliminar")//sino es Eliminar, es Modificar
            {
                //falta confirmacion de eliminar...
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.Eliminar(id);
                Response.Redirect("Cliente.aspx");
            }
            else
            {
                Response.Redirect("FormCliente.aspx?id=" + id);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();   
            dgvClientes.DataSource = clienteNegocio.Listar().FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())
                                                                        ||x.Apellido.ToUpper().Contains(txtBuscar.Text.ToUpper())
                                                                        || x.Id.ToString().ToUpper().Contains(txtBuscar.Text.ToUpper()));
            dgvClientes.DataBind();
        }
    }
}
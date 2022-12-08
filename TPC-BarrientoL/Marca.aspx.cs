using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            dgvMarcas.DataSource = negocio.Listar();
            dgvMarcas.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMarca.aspx");
        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvMarcas.DataKeys[indice].Value.ToString());

            if (e.CommandName.ToString()== "Eliminar")//sino es Eliminar, es Modificar
            {
                //falta confirmacion de eliminar...
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Eliminar(id);
                Response.Redirect("Marca.aspx");
            }
            else
            {
                Response.Redirect("FormMarca.aspx?id=" + id);
            }           
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            dgvMarcas.DataSource = negocio.Listar().FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            dgvMarcas.DataBind();

        }
    }
}
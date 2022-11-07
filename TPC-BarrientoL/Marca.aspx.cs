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

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMarca.aspx");
            
        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvMarcas.DataKeys[indice].Value.ToString());

            if (e.CommandName.ToString()== "Eliminar")
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Eliminar(id);
            }
            else
            {
                //falta confirmacion de eliminar...
                Response.Redirect("FormMarca.aspx?id=" + id);
            }           
        }
    }
}
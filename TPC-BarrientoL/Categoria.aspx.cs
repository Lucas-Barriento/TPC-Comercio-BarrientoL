using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
namespace TPC_BarrientoL
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvCategorias.DataSource = negocio.Listar();
            dgvCategorias.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCategoria.aspx");
        }

        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvCategorias.DataKeys[indice].Value.ToString());
            if (e.CommandName.ToString()=="Eliminar")
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.Eliminar(id);
                Response.Redirect("Categoria.aspx");
            }
            else
            {
                Response.Redirect("FormCategoria.aspx?id=" + id);
            }
        }
    }
}
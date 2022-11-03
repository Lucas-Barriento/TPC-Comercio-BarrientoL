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
            CategoriasNegocio negocio = new CategoriasNegocio();
            dgvCategorias.DataSource = negocio.Listar();
            dgvCategorias.DataBind();
        }
    }
}
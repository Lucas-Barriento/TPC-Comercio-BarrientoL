using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompraNegocio negocio = new CompraNegocio();
            dgvCompras.DataSource = negocio.Listar();
            dgvCompras.DataBind();
        }

        protected void dgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}
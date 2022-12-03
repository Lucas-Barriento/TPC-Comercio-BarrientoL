using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class DetalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            DetalleTransactionNegocio detalle = new DetalleTransactionNegocio();
            dgvDetalleCompras.DataSource = detalle.ListarCompra(id);
            dgvDetalleCompras.DataBind();
        }
    }
}
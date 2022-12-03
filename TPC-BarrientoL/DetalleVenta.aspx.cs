using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace TPC_BarrientoL
{
    public partial class DetalleVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            DetalleTransactionNegocio detalle = new DetalleTransactionNegocio();
            dgvDetalleVentas.DataSource = detalle.ListarVenta(id);
            dgvDetalleVentas.DataBind();
        }
    }
}
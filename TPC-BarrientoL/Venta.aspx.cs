using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static TPC_BarrientoL.Functions.Validaciones;

namespace TPC_BarrientoL
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
            dgvVentas.DataSource = negocio.Listar();
            dgvVentas.DataBind();
            
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var indice = int.Parse(e.CommandArgument.ToString());
            var id = int.Parse(dgvVentas.DataKeys[indice].Value.ToString());

            Response.Redirect("DetalleVenta.aspx?id=" + id);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormVenta.aspx");
        }
    }
}
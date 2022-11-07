using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_BarrientoL
{
    public partial class FormMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)///si se envia un id en la direccion de la pagina 
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                MarcaNegocio negocio = new MarcaNegocio();
                Marca seleccionado = negocio.Listar().Find(x => x.Id == id);//busca en la lista la coincidencia
                //precargar los datos del id seleccionado
                txtBoxId.Text = seleccionado.Id.ToString();
                txtBoxId.ReadOnly = true;
                txtBoxNombre.Text = seleccionado.Nombre.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.Nombre = txtBoxNombre.Text;
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            marcaNegocio.Modificar(marca);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marca.aspx");
        }
    }
}
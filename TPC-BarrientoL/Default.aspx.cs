using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using static TPC_BarrientoL.Functions.Validaciones;


namespace TPC_BarrientoL
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario= new Usuario();
            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Password = txtUsuario.Text;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            if (usuarioNegocio.IngresarUsuario(usuario))
            {
                Session.Add("Usuario", usuario);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session.Add("Eror", "El nombre de usuario o contraseña son incorrectos");
                MessageBox.Show("El nombre de usuario o contraseña son incorrectos");
                //message box
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion(Page);
        }
    }
}
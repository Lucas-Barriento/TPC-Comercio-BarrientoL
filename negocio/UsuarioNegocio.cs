using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool IngresarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
            datos.SetConsulta("select Id,Usuario,Pass,Tipo from USUARIO where Usuario =@IdUsuario and Pass=@Pass");
            datos.SetParametros("@IdUsuario", usuario.NombreUsuario);
            datos.SetParametros("@Pass", usuario.Password);
            datos.ejecutarLectura();
                while (datos.LectorSql.Read())
                {
                    usuario.Id = (int)datos.LectorSql["Id"];
                    usuario.TipoUsuario = ((int)(datos.LectorSql["Tipo"])==2 ?TipoUsuario.Admin : TipoUsuario.Vendedor);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

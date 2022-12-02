using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web;
using dominio;
using negocio;

namespace TPC_BarrientoL.Functions
{
    public class Validaciones
    {
        public static bool SesionIniciada(Page page)
        {
            if (page.Session["usuario"] != null)
            {
                return true;
            }
            return false;
        }

        public static bool EsAdmin(Page page)
        {
            if (page.Session["usuario"] != null && ((Usuario)page.Session["usuario"]).TipoUsuario == TipoUsuario.Admin)
            {
                return true;
            }
            return false;
        }
        
        public static void CerrarSesion(Page page)
        {
            page.Session.Remove("Usuario");
        }
    }
}
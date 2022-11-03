using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriasNegocio
    {
        public List<Categorias> Listar()
        {
            List<Categorias> Lista = new List<Categorias>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetConsulta("select Id,Nombre from CATEGORIAS");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Categorias categoria = new Categorias();
                    categoria.Id = (int)Datos.LectorSql["Id"];
                    categoria.Nombre = (string)Datos.LectorSql["nombre"];

                    Lista.Add(categoria);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }
    }
}

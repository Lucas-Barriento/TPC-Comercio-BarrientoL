using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> Lista = new List<Categoria>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetConsulta("select Id,Nombre from CATEGORIA");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Categoria categoria = new Categoria();
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

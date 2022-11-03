using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcasNegocio
    {
        public List<Marcas> Listar()
        {

            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("select Id,Nombre from MARCAS");
                datos.ejecutarLectura();

                while (datos.LectorSql.Read())
                {
                    //se crea un aux, se le asigna los datos del lector y se agrega a la lista
                    Marcas marca = new Marcas();
                    marca.Id = (int)datos.LectorSql["Id"];
                    marca.Nombre = (string)datos.LectorSql["Nombre"];

                    lista.Add(marca);
                }
                return lista;
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

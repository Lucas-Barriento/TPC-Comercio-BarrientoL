using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {

            List<Cliente> Lista = new List<Cliente>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("select Id,Nombre from CLIENTE");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Cliente Cliente = new Cliente();
                    Cliente.ID = (int)Datos.LectorSql["Id"];
                    Cliente.Nombre = (string)Datos.LectorSql["Nombre"];
                    Cliente.Apellido = (string)Datos.LectorSql["Apellido"];
                    Lista.Add(Cliente);
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

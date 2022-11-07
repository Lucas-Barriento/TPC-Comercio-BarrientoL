using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> Listar()
        {

            List<Proveedor> Lista = new List<Proveedor>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("select Id,Nombre from PROVEEDOR");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    //se crea un aux, se le asigna los datos del lector y se agrega a la lista
                    Proveedor Proveedor = new Proveedor();
                    Proveedor.ID = (int)Datos.LectorSql["Id"];
                    Proveedor.Nombre = (string)Datos.LectorSql["Nombre"];

                    Lista.Add(Proveedor);
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

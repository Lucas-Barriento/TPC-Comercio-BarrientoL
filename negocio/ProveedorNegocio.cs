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
                Datos.SetConsulta("select Id,Nombre,Estado from PROVEEDOR");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Proveedor Proveedor = new Proveedor();
                    Proveedor.Id = (int)Datos.LectorSql["Id"];
                    Proveedor.Nombre = (string)Datos.LectorSql["Nombre"];
                    Proveedor.Estado = (bool)Datos.LectorSql["Estado"];

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
        public void Agregar(Proveedor Nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into PROVEEDOR (Nombre,Estado)values('" + Nuevo.Nombre + "','" + Nuevo.Estado + "')");
                Datos.ejecutarAccion();
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
        public void Modificar(Proveedor proveedor)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("update CATEGORIA set Nombre=@Nombre, Estado=@Estado where Id=@id");
                Datos.SetParametros("@Nombre", proveedor.Nombre);
                Datos.SetParametros("@Estado", proveedor.Estado);
                Datos.SetParametros("@id", proveedor.Id);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(int id)//eliminar con numero de id
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("delete from PROVEEDOR where id=@id");
                Datos.SetParametros("@id", id);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

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
                Datos.SetConsulta("select Id,Nombre,Apellido,Estado from CLIENTE");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Cliente Cliente = new Cliente();
                    Cliente.Id = (int)Datos.LectorSql["Id"];
                    Cliente.Nombre = (string)Datos.LectorSql["Nombre"];
                    Cliente.Apellido = (string)Datos.LectorSql["Apellido"];
                    Cliente.Estado = (bool)Datos.LectorSql["Estado"];
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
        public void Agregar(Cliente Nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into Cliente (Id,Nombre,Apellido,Estado)values('"+Nuevo.Id+"' ,'" + Nuevo.Nombre + "','" + Nuevo.Apellido + "','"+Nuevo.Estado + "')");
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
        public void Eliminar(int id)//eliminar con numero de id
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("delete from CLIENTE where id=@id");
                Datos.SetParametros("@id", id);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Cliente cliente)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("update CLIENTE set Nombre=@Nombre,Apellido=@Apellido, Estado=@Estado where Id=@id");
                Datos.SetParametros("@Nombre", cliente.Nombre);
                Datos.SetParametros("@Apellido", cliente.Apellido);
                Datos.SetParametros("@Estado", cliente.Estado);
                Datos.SetParametros("@id", cliente.Id);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

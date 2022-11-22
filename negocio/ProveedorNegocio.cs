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
                Datos.SetConsulta("select Id,Nombre,Domicilio,Localidad,Email,Telefono,Estado from PROVEEDOR");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Proveedor Proveedor = new Proveedor();
                    Proveedor.Id = (int)Datos.LectorSql["Id"];
                    Proveedor.Nombre = (string)Datos.LectorSql["Nombre"];
                    Proveedor.Domicilio = (string)Datos.LectorSql["Domicilio"];
                    Proveedor.Localidad = (string)Datos.LectorSql["Localidad"];
                    Proveedor.Email = (string)Datos.LectorSql["Email"];
                    Proveedor.Telefono = (string)Datos.LectorSql["Telefono"];
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
                Datos.SetConsulta("insert into PROVEEDOR (Nombre,Domicilio,Localidad,Email,Telefono,Estado)values('" + Nuevo.Nombre + "','" + Nuevo.Domicilio + "','"+Nuevo.Localidad+"','"+Nuevo.Email+"','"+Nuevo.Telefono+"','"+ Nuevo.Estado + "')");
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
                Datos.SetConsulta("update PROVEEDOR set Nombre=@Nombre,Domicilio=@domicilio,Localidad=@localidad,Email=@email,Telefono=@telefono, Estado=@Estado where Id=@id");
                Datos.SetParametros("@Nombre", proveedor.Nombre);
                Datos.SetParametros("@Domicilio",proveedor.Domicilio);
                Datos.SetParametros("@Localidad", proveedor.Localidad);
                Datos.SetParametros("@email", proveedor.Email);
                Datos.SetParametros("@telefono", proveedor.Telefono);
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

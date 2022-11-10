using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                Datos.SetConsulta("select Id,Nombre,Estado from CATEGORIA");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)Datos.LectorSql["Id"];
                    categoria.Nombre = (string)Datos.LectorSql["nombre"];
                    categoria.Estado = (bool)Datos.LectorSql["Estado"];

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
        public void Agregar(Categoria Nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into CATEGORIA (Nombre,Estado)values('" + Nuevo.Nombre + "','" + Nuevo.Estado + "')");
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
        public void Modificar(Categoria categoria)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("update CATEGORIA set Nombre=@Nombre, Estado=@Estado where Id=@id");
                Datos.SetParametros("@Nombre", categoria.Nombre);
                Datos.SetParametros("@Estado", categoria.Estado);
                Datos.SetParametros("@id", categoria.Id);
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
                Datos.SetConsulta("delete from CATEGORIA where id=@id");
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

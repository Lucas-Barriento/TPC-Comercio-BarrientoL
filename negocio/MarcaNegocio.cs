using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {

            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("select Id,Nombre from MARCA");
                datos.ejecutarLectura();

                while (datos.LectorSql.Read())
                {
                    //se crea un aux, se le asigna los datos del lector y se agrega a la lista
                    Marca marca = new Marca();
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
        public void Agregar(Marca Nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into MARCA (ID,Nombre)values('" + Nuevo.Id + "','" + Nuevo.Nombre);
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
        public void Modificar(Marca marca)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("update Marca set Nombre=@Nombre where Id=@id");
                Datos.SetParametros("@Nombre",marca.Nombre);
                Datos.SetParametros("@id", marca.Id);
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
                Datos.SetConsulta("delete from MARCA where id=@id");
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
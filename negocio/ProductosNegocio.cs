using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProductosNegocio
    {
        //funcion listar que devuelve una lista de articulos
        public List<Productos> ListarProductos()
        {
            List<Productos> Lista = new List<Productos>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("select * from Productos");//hay que modificar
                Datos.ejecutarLectura();
                while (Datos.LectorSql.Read())
                {
                    Productos Aux = new Productos();
                    Aux.ID = (int)Datos.LectorSql["Id"];
                    Aux.Nombre = (string)Datos.LectorSql["Nombre"];

                    Aux.Marca = new Marcas();
                    Aux.Marca.Id = (int)Datos.LectorSql["IdMar"];
                    Aux.Marca.Nombre = (string)Datos.LectorSql["Marca"];
                    
                    Aux.Categoria = new Categorias();
                    Aux.Categoria.Id = (int)Datos.LectorSql["IdCat"];
                    Aux.Categoria.Nombre = (string)Datos.LectorSql["Categoria"];

                    Aux.Stock = (int)Datos.LectorSql["Stock"];
                    Aux.StockMinimo = (int)Datos.LectorSql["StockMinimo"];
                    Aux.PorcentajeGanancia = Math.Round((decimal)Datos.LectorSql["Precio"], 2);

                    Lista.Add(Aux);

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
        public void Agregar(Productos Nuevo)
        {
            //abrir conexion a base de datos
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into PRODUCTOS (ID,Nombre,Descripcion,IdMarcas,IdCategorias,Stock,StockMinimo,Ganancia)values('" + Nuevo.ID + "','" + Nuevo.Nombre + "',@IdMarcas,@IdCategorias,'" + Nuevo.Stock + "','" + Nuevo.StockMinimo + "','" + Nuevo.PorcentajeGanancia + "')");
                Datos.SetParametros("@IdMarcas", Nuevo.Marca.Id);
                Datos.SetParametros("@IdCategorias", Nuevo.Categoria.Id);
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
                Datos.SetConsulta("delete from PRODUCTOS where id=@id");
                Datos.SetParametros("@id", id);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //falta la funcion modificar



    }
}

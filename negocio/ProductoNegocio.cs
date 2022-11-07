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
    public class ProductoNegocio
    {
        //funcion listar que devuelve una lista de articulos
        public List<Producto> ListarProductos()
        {
            List<Producto> Lista = new List<Producto>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("select P.Id, P.Nombre, M.Nombre Marca, M.Id IdMar, C.Nombre Categoria, C.Id IdCat, P.Stock, P.StockMinimo, P.PorcentajeGanancia from PRODUCTO P, MARCA M, CATEGORIA C where P.IdCategoria = C.Id and P.IdMarca = M.Id");
                Datos.ejecutarLectura();
                while (Datos.LectorSql.Read())
                {
                    Producto Aux = new Producto();
                    Aux.ID = (int)Datos.LectorSql["Id"];
                    Aux.Nombre = (string)Datos.LectorSql["Nombre"];
                    Aux.PorcentajeGanancia = (decimal)Datos.LectorSql["PorcentajeGanancia"];
                    Aux.Marca = new Marca();
                    Aux.Marca.Id = (int)Datos.LectorSql["IdMar"];
                    Aux.Marca.Nombre = (string)Datos.LectorSql["Marca"];
                    
                    Aux.Categoria = new Categoria();
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
        public void Agregar(Producto Nuevo)
        {
            //abrir conexion a base de datos
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into PRODUCTO (ID,Nombre,Descripcion,IdMarcas,IdCategorias,Stock,StockMinimo,Ganancia)values('" + Nuevo.ID + "','" + Nuevo.Nombre + "',@IdMarcas,@IdCategorias,'" + Nuevo.Stock + "','" + Nuevo.StockMinimo + "','" + Nuevo.PorcentajeGanancia + "')");
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
                Datos.SetConsulta("delete from PRODUCTO where id=@id");
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

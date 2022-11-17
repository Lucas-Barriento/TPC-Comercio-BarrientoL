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
                Datos.SetConsulta("select P.Id, P.Nombre,M.id idMar, M.Nombre Marca,C.id idCat, C.Nombre Categoria,PROV.id idProv,PROV.Nombre Proveedor, P.Stock, P.StockMinimo, P.PorcentajeGanancia,P.Estado from PRODUCTO P, MARCA M, CATEGORIA C, PROVEEDOR PROV where P.IdCategoria = C.Id and P.IdMarca = M.Id and P.IdProveedor=PROV.Id");
                Datos.ejecutarLectura();
                while (Datos.LectorSql.Read())
                {
                    Producto Aux = new Producto();
                    Aux.Id = (int)Datos.LectorSql["Id"];
                    Aux.Nombre = (string)Datos.LectorSql["Nombre"];
                    
                    Aux.Marca = new Marca();
                    Aux.Marca.Id = (int)Datos.LectorSql["idMar"];
                    Aux.Marca.Nombre = (string)Datos.LectorSql["Marca"];
                    
                    Aux.Categoria = new Categoria();
                    Aux.Categoria.Id = (int)Datos.LectorSql["idCat"];
                    Aux.Categoria.Nombre = (string)Datos.LectorSql["Categoria"];

                    Aux.Proveedor= new Proveedor();
                    Aux.Proveedor.Id= (int)Datos.LectorSql["idProv"];
                    Aux.Proveedor.Nombre = (string)Datos.LectorSql["Proveedor"];

                    Aux.Stock = (int)Datos.LectorSql["Stock"];
                    Aux.StockMinimo = (int)Datos.LectorSql["StockMinimo"];
                    Aux.PorcentajeGanancia = (decimal)Datos.LectorSql["PorcentajeGanancia"];
                    Aux.Estado = (bool)Datos.LectorSql["Estado"];
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
                Datos.SetConsulta("insert into PRODUCTO (Nombre,IdMarca,IdCategoria,IdProveedor,Stock,StockMinimo,PorcentajeGanancia,Estado)values('" + Nuevo.Nombre + "',@IdMarcas,@IdCategorias,@idProveedores,'" + Nuevo.Stock + "','" + Nuevo.StockMinimo + "','" + Nuevo.PorcentajeGanancia + "','"+Nuevo.Estado+"')");
                Datos.SetParametros("@IdMarcas", Nuevo.Marca.Id);
                Datos.SetParametros("@IdCategorias", Nuevo.Categoria.Id);
                Datos.SetParametros("@IdProveedores", Nuevo.Proveedor.Id);
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
            finally
            {
                Datos.cerrarConexion();
            }
        }
        public void Modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("update Producto set NOMBRE=@Nombre,IDMARCA=@IdMarca,IDCATEGORIA=@IdCategoria,IDPROVEEDOR=@IdProveedor,STOCK=@Stock,STOCKMINIMO=@StockMinimo,PORCENTAJEGANANCIA=@PorcentajeGanacia,ESTADO=@Estado where id=@Id");
                datos.SetParametros("@Id",producto.Id );
                datos.SetParametros("@Nombre", producto.Nombre);
                datos.SetParametros("@IdMarca",producto.Marca.Id);
                datos.SetParametros("@IdCategoria",producto.Categoria.Id);
                datos.SetParametros("@IdProveedor",producto.Proveedor.Id);
                datos.SetParametros("@Stock",producto.Stock);
                datos.SetParametros("@StockMinimo",producto.StockMinimo);
                datos.SetParametros("@PorcentajeGanacia",producto.PorcentajeGanancia);
                datos.SetParametros("@Estado",producto.Estado);
                datos.ejecutarAccion();
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

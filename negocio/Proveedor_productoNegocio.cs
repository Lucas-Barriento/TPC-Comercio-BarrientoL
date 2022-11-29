using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Proveedor_productoNegocio
    {
        public List<Proveedor_Producto> Listar()
        {
            List<Proveedor_Producto> lista = new List<Proveedor_Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("select IdProducto,IdProveedor from PROVEEDORES_PRODUCTOS");
                datos.ejecutarLectura();
                while (datos.LectorSql.Read())
                {
                    Proveedor_Producto aux = new Proveedor_Producto();
                    aux.IdProducto = (int)datos.LectorSql["IdProducto"];
                    aux.IdProveedor = (int)datos.LectorSql["IdProveedor"];
                    lista.Add(aux);
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

        public void Agregar(Proveedor_Producto nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into PROVEEDORES_PRODUCTOS (idProducto,idProveedor)values('" + nuevo.IdProducto + "','" + nuevo.IdProveedor + "')");
                Datos.ejecutarAccion() ;
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
        public void AgregarConSP(Proveedor_Producto nuevo)//se agregan los proveedores al producto recien creado
        {
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.SetConsulta("EXEC SP_INSERTPROVEEDOR_NUEVOPRODUCTO '" + nuevo.IdProveedor + "'") ;
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

        public void Eliminar(int idProducto)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("EXEC SP_ELIMINAR_PROVEEDORESXIDPRODUCTO'" + idProducto + "'");
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                    throw ex;
            }
            finally { Datos.cerrarConexion();}
        }

        
    }
}

using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DetalleTransactionNegocio
    {
        public List<DetalleTransaccion> ListarXProducto(int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DetalleTransaccion> lista = new List<DetalleTransaccion>();
            try
            {
                datos.SetConsulta("select IdProducto,P.Nombre,P.Precio,IdCompra,Cantidad,PrecioParcial from DETALLECOMPRA,PRODUCTO P where IdProducto=@idProducto and P.Id=IdProducto ");
                datos.SetParametros("@idProducto", idProducto);
                datos.ejecutarLectura();
                while (datos.LectorSql.Read())
                {
                    DetalleTransaccion aux = new DetalleTransaccion();
                    aux.IdTransaccion = (int)datos.LectorSql["IdCompra"];
                    aux.Cantidad = (int)datos.LectorSql["Cantidad"];
                    aux.PrecioParcial = (decimal)datos.LectorSql["PrecioParcial"];

                    aux.producto = new Producto();
                    aux.producto.Nombre = (string)datos.LectorSql["P.Nombre"];
                    aux.producto.Precio = (decimal)datos.LectorSql["P.Precio"];

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

        public void AgregarCompraConSP(DetalleTransaccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("EXEC SP_AGREGAR_ITEMS_COMPRA '"+nuevo.producto.Id+"','"+nuevo.Cantidad+"','"+ Convert.ToDouble(nuevo.PrecioParcial)+"'");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

        public void AgregarVentaConSP(DetalleTransaccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("EXEC SP_AGREGAR_ITEMS_VENTA '" + nuevo.producto.Id + "','" + nuevo.Cantidad + "','" + Convert.ToDouble(nuevo.PrecioParcial) + "'");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        
        public List<DetalleTransaccion> ListarVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DetalleTransaccion> lista = new List<DetalleTransaccion>();
            try
            {
                datos.SetConsulta("select DV.Id,IdProducto,P.Nombre,P.Precio,IdVenta,Cantidad,PrecioParcial from DETALLEVENTA DV,PRODUCTO P where IdVenta=@idVenta and P.Id=IdProducto");
                datos.SetParametros("@idVenta", idVenta);
                datos.ejecutarLectura();
                while (datos.LectorSql.Read())
                {
                    DetalleTransaccion aux = new DetalleTransaccion();
                    aux.Id = (int)datos.LectorSql["Id"];
                    aux.IdTransaccion = (int)datos.LectorSql["IdVenta"];
                    aux.Cantidad = (int)datos.LectorSql["Cantidad"];
                    aux.PrecioParcial = (decimal)datos.LectorSql["PrecioParcial"];

                    aux.producto = new Producto();
                    aux.producto.Id = (int)datos.LectorSql["IdProducto"];
                    aux.producto.Nombre = (string)datos.LectorSql["Nombre"];
                    aux.producto.Precio = (decimal)datos.LectorSql["Precio"];

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

        public List<DetalleTransaccion> ListarCompra(int idCompra)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DetalleTransaccion> lista = new List<DetalleTransaccion>();
            try
            {
                datos.SetConsulta("select DC.Id,IdProducto,P.Nombre,P.Precio,IdCompra,Cantidad,PrecioParcial from DETALLECOMPRA DC,PRODUCTO P where IdCompra=@idCompra and P.Id=IdProducto");
                datos.SetParametros("@idCompra", idCompra);
                datos.ejecutarLectura();
                while (datos.LectorSql.Read())
                {
                    DetalleTransaccion aux = new DetalleTransaccion();
                    aux.Id = (int)datos.LectorSql["Id"];
                    aux.IdTransaccion = (int)datos.LectorSql["IdCompra"];
                    aux.Cantidad = (int)datos.LectorSql["Cantidad"];
                    aux.PrecioParcial = (decimal)datos.LectorSql["PrecioParcial"];

                    aux.producto = new Producto();
                    aux.producto.Id = (int)datos.LectorSql["IdProducto"];
                    aux.producto.Nombre = (string)datos.LectorSql["Nombre"];
                    aux.producto.Precio = (decimal)datos.LectorSql["Precio"];

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

    }
}

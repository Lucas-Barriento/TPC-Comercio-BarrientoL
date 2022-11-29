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
                datos.SetConsulta("select IdProducto,IdCompra,Cantidad,PrecioParcial from DETALLECOMPRA where IdProducto='"+idProducto+"'");
                datos.ejecutarLectura();
                while (datos.LectorSql.Read())
                {
                    DetalleTransaccion aux = new DetalleTransaccion();
                    aux.IdProducto = (int)datos.LectorSql["IdProducto"];
                    aux.IdTransaccion = (int)datos.LectorSql["IdCompra"];
                    aux.Cantidad = (int)datos.LectorSql["Cantidad"];
                    aux.PrecioParcial = (decimal)datos.LectorSql["PrecioParcial"];
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

        public void AgregarConSP(DetalleTransaccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("EXEC SP_AGREGAR_ITEMS_COMPRA '"+nuevo.IdProducto+"','"+nuevo.Cantidad+"','"+nuevo.PrecioParcial+"'");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

    }
}

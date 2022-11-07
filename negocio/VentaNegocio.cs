using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        public List<Venta> Listar()
        {

            List<Venta> Lista = new List<Venta>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("select IDVENTA, IDCLIENTE,PRECIOFINAL from venta");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Venta Venta = new Venta();
                    Venta.IdVenta = (int)Datos.LectorSql["IDVENTA"];
                    Venta.IdCliente = (int)Datos.LectorSql["IDCLIENTE"];
                    Venta.PrecioFinal = (decimal)Datos.LectorSql["PRECIOFINAL"];

                    Lista.Add(Venta);
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
    }
}

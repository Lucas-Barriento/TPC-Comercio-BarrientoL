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
                Datos.SetConsulta("select V.IdVenta,C.Id IdCliente, C.Nombre Nombre,C.Apellido Apellido,V.PrecioFinal from VENTA V,CLIENTE C where v.IdCliente=c.Id");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Venta Venta = new Venta();
                    Venta.IdVenta = (int)Datos.LectorSql["IDVENTA"];
                    Venta.PrecioTotal = (decimal)Datos.LectorSql["PRECIOFINAL"];

                    Venta.cliente = new Cliente();
                    Venta.cliente.Id = (int)Datos.LectorSql["IdCliente"];
                    Venta.cliente.Nombre = (string)Datos.LectorSql["Nombre"];
                    Venta.cliente.Apellido = (string)Datos.LectorSql["Apellido"];
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

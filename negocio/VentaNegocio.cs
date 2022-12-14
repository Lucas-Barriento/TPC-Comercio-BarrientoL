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
                Datos.SetConsulta("select V.Id IdVenta,C.Id IdCliente, C.Nombre Nombre,C.Apellido Apellido,V.FechaVenta,V.PrecioFinal from VENTA V,CLIENTE C where v.IdCliente=c.Id");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Venta Venta = new Venta();
                    Venta.IdVenta = (int)Datos.LectorSql["IdVenta"];
                    Venta.PrecioTotal = (decimal)Datos.LectorSql["PrecioFinal"];
                    Venta.FechaVenta = (DateTime)Datos.LectorSql["FechaVenta"];

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

        public void Agregar(Venta nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetConsulta("insert into VENTA (IDCLIENTE,FECHAVENTA,PRECIOFINAL)values(@IdCliente,'" + nuevo.FechaVenta + "','" + Convert.ToDouble(nuevo.PrecioTotal) + "')");
                datos.SetParametros("@IdCliente", nuevo.cliente.Id);
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

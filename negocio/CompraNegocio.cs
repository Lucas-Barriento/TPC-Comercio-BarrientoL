using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CompraNegocio
    {
        public List<Compra> Listar()
        {

            List<Compra> Lista = new List<Compra>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("select C.ID,P.NOMBRE Proveedor,P.ID idProv, C.FECHACOMPRA, C.PRECIOTOTAL from COMPRA C,PROVEEDOR P where C.IDPROVEEDOR=P.ID");
                Datos.ejecutarLectura();

                while (Datos.LectorSql.Read())
                {
                    Compra Compra = new Compra();
                    Compra.ID = (int)Datos.LectorSql["Id"];
                    Compra.FechaCompra = (DateTime)Datos.LectorSql["FechaCompra"];
                    Compra.PrecioTotal = (decimal)Datos.LectorSql["PrecioCompra"];

                    Compra.Proveedor = new Proveedor();
                    Compra.Proveedor.Id = (int)Datos.LectorSql["IdProv"];
                    Compra.Proveedor.Nombre = (string)Datos.LectorSql["Proveedor"];

                    Lista.Add(Compra);
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

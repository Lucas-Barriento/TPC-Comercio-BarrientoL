using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetalleTransaccion //detalle de compra y venta
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdTransaccion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioParcial { get; set; }
    }
}

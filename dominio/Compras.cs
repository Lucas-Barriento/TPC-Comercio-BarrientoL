using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Compras
    {
        public int ID { get; set; }
        public Proveedores Proveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}

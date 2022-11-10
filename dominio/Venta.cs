using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente cliente { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}

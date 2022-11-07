using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ProductoVenta : Producto
    {
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioParcial { get; set; }
    }
}

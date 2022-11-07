using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ProductoCompra:Producto
    {
        public int IdCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioParcial { get; set; }
    }
}

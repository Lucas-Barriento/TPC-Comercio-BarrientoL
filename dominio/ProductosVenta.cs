using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ProductosVenta : Productos
    {
        public int IdCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Productos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Marcas Marca { get; set; }
        public Categorias Categoria { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PorcentajeGanancia { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PorcentajeGanancia { get; set; }
    }
}
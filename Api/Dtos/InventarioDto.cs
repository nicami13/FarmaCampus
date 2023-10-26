using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos

{
    public class InventarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProducto { get; set; }
        public int IdPresentacion { get; set; }
        public double Precio { get; set; }
        public int StockMax { get; set; }
        public int StockMin { get; set; }
        public int Stock { get; set; }
    }
}
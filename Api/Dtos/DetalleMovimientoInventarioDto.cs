using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class DetalleMovimientoInventarioDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int IdMovimientoInventario { get; set; }
        public int IdInventario { get; set; }
    }
}
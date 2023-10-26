using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleMovimientoInventario:BaseEntity
    {
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int IdMovimientoInventario { get; set; }
        public MovimientoInventario MovimientosInventarios { get; set; }
        public int IdInventario { get; set; }
        public Inventario Inventarios { get; set; }
    }
}
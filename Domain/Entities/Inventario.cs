using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventario:BaseEntity
    {
        public string Nombre { get; set; }
        public int IdProducto { get; set; }
        public Producto Productos { get; set; }
        public int IdPresentacion { get; set; }
        public Presentacion Presentaciones { get; set; }
        public double Precio { get; set; }
        public int StockMax { get; set; }
        public int StockMin { get; set; }
        public int Stock { get; set; }
        public ICollection<DetalleMovimientoInventario> DetallesMovimientosInventarios { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovimientoInventario:BaseEntity
    {
        public int IdResponsable { get; set; }
        public Persona Personas { get; set; }
        public int IdReceptor { get; set; }
        public Persona Personas2 { get; set; }
        public int IdTipoMovimientoInventario { get; set; }
        public TipoMovimientoInventario TiposMovimientosInventarios { get; set; }
        public DateOnly FechaMovimiento { get; set; }
        public DateOnly FechaVencimiento { get; set; }

        public ICollection<DetalleMovimientoInventario> DetallesMovimientosInventarios { get; set; }
    }
}
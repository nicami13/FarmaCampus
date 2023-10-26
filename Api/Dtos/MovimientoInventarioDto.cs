using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Api.Dtos

{
    public class MovimientoInventarioDto
    {
        public int Id { get; set; }
        public int IdResponsable { get; set; }
        public DateOnly FechaMovimiento { get; set; }
        public DateOnly FechaVencimiento { get; set; }
        public int IdTipoMovimientoInventario { get; set; }
    }
}
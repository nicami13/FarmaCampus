using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Factura:BaseEntity
    {
        public int FacturaInicial { get; set; }
        public int FacturaActual { get; set; }
        public string NroResolucion { get; set; }
    }
}
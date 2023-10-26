using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona:BaseEntity
    {
        public string Nombre { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public int IdDocumento { get; set; }
        public TipoDocumento TiposDocumentos { get; set; }
        public int IdRolPersona { get; set; }
        public RolPersona RolesPersonas { get; set; }
        public int IdTipoPersona { get; set; }
        public TipoPersona TiposPersonas { get; set; }

        public ICollection<ContactoPersona> ContactosPersonas { get; set; }
        public ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
        public ICollection<UbicacionPersona> UbicacionPersonas { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TipoDocumento : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
     public ICollection<Persona> Personas { get; set; }
}



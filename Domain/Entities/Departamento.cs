using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departamento:BaseEntity
    {


        public string Nombre { get; set; }
        public int Idpais { get; set; }
        public Pais Paises { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; }
    }
}
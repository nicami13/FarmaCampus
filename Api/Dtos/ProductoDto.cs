using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos

{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }  
        public int IdMarca { get; set; }
    }
}
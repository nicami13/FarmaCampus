using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Domain.Repositories
{
    public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumento
    {
        private readonly InventarioContext _context;

        public TipoDocumentoRepository(InventarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
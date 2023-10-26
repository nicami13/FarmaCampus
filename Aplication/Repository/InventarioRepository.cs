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
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        private readonly InventarioContext _context;

        public InventarioRepository(InventarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
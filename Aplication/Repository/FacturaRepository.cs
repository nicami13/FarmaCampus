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
    public class FacturaRepository : GenericRepository<Factura>, IFactura
    {
        private readonly InventarioContext context;

        public FacturaRepository(InventarioContext context) : base(context)
        {
            this.context = context;
        }
    }
}
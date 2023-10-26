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
    public class FormaPagoRepository : GenericRepository<FormaPago>, IFormaPago
    {
        private readonly InventarioContext _context;

        public FormaPagoRepository(InventarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
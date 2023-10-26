using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Persistence.Data;

namespace Aplication.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly InventarioContext _context;

        public RolRepository(InventarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
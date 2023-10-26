using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Domain.Repositories;

    public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
    {
        private readonly InventarioContext _context;

        public ContactoPersonaRepository(InventarioContext context) : base(context)
        {
            _context = context;
        }
    }

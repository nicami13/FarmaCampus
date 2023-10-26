using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Domain.Repositories;

public class CiudadRepository : GenericRepository<Ciudad>,ICiudad
{
    private readonly InventarioContext _context;

    public CiudadRepository(InventarioContext context) : base(context)
    {
        _context = context;
    }
}

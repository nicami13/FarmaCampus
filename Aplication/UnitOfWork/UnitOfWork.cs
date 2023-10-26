using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Aplication.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IRolRepository _Roles;
         private IUserRepository _Users;
        private readonly InventarioContext _context;

        public UnitOfWork(InventarioContext context)
        {
            _context=context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public IRolRepository Roles{
            get 
            {
            if(Roles==null)
            {
                _Roles=new RolRepository(_context);
            }
            return _Roles;
            }
        }
        public IUserRepository Users
        {
            get{
                if(_Users==null){
                    _Users= new UserRepository(_context);
                }
                return _Users;
            }
        }
}
}
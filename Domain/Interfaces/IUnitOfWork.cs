using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRolRepository Roles { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
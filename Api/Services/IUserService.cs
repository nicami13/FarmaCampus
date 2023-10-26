using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;

namespace Api.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegistrosDto model);
        Task<DataUSerDto> GetTokenAsync(LoginDto model);
        Task<string> AddRoleAsync(AddRoleDto model);
        Task<DataUSerDto> RefreshTokenAsync(string refreshToken);
    }
}
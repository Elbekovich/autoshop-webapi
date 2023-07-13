using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Users;
using AutoShop.Service.Dtos.Users;
using AutoShop.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShop.Service.Services.Users;

public class UserService : IUserService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(UserCreateDto userCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }
}

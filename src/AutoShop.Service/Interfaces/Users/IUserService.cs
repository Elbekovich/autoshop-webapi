using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Users;
using AutoShop.Service.Dtos.Users;

namespace AutoShop.Service.Interfaces.Users;

public interface IUserService
{
    
    public Task<long> CreateAsync(UserCreateDto userCreateDto);

    public Task<bool> DeleteAsync(long id);

    public Task<long> CountAsync();

    public Task<IList<User>> GetAllAsync(PaginationParams @params);

    public Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto);

    //public Task<bool> LoginUser(string email, string password);
    public Task<IList<User>> LoginUser(string email, string password);

    public Task<List<User>> GetLastCreatedUserAsync();


    //public Task<List<User>> LoginUserWithData(string email, string password);

    //GetLastCreatedUserAsync

}

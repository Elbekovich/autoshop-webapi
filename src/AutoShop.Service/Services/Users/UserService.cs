using AutoShop.DataAccess.Interfaces.Users;
using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Users;
using AutoShop.Domain.Exceptions.Users;
using AutoShop.Service.Common.Helpers;
using AutoShop.Service.Common.Security;
using AutoShop.Service.Dtos.Users;
using AutoShop.Service.Interfaces.Users;

namespace AutoShop.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<long> CountAsync() => await _userRepository.CountAsync();

    //public async Task<bool> LoginUser(string email, string password)
    //{
    //    var user = await _userRepository.GetUserByEmail(email);

    //    if (user != null)
    //    {
    //        bool isPasswordCorrect = PasswordHasher.Verify(password, user.PasswordHash, user.Salt);

    //        if (isPasswordCorrect)
    //        {
    //            return true; 
    //        }
    //    }

    //    return false;
    //}


    public async Task<long> CreateAsync(UserCreateDto userCreateDto)
    {

        User us = new User()
        {
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            PhoneNumber = userCreateDto.PhoneNumber,
            Region = userCreateDto.Region,
            PasswordHash = userCreateDto.PasswordHash,
            Email = userCreateDto.Email,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var hashres = PasswordHasher.Hash(us.PasswordHash);
        us.Salt = hashres.Salt;
        us.PasswordHash = hashres.PasswordHash;



        var res = await _userRepository.CreateAsync(us);
        //return res > 0;
        return res;
    }

    public async Task<List<User>> GetLastCreatedUserAsync()
    {
        List<User> lastCreatedUsers = new List<User>();
        User lastCreatedUser = await _userRepository.GetLastCreatedUserAsync();
        if (lastCreatedUser != null)
        {
            lastCreatedUsers.Add(lastCreatedUser);
        }

        return lastCreatedUsers;
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) throw new UsersNotFoundException();
        var result = await _userRepository.DeleteAsync(id);
        return result > 0;
    }

    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        var userss = await _userRepository.GetAllAsync(@params);
        return userss;
    }


    public async Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto)
    {
        var userss = await _userRepository.GetByIdAsync(id); //@id
        if (userss is null) throw new UsersNotFoundException();
        userss.FirstName = userUpdateDto.FirstName;
        userss.LastName = userUpdateDto.LastName;
        userss.PhoneNumber = userUpdateDto.PhoneNumber;
        userss.Region = userUpdateDto.Region;
        userss.PasswordHash = userUpdateDto.PasswordHash;
        var hashres = PasswordHasher.Hash(userss.PasswordHash);
        userss.PasswordHash = hashres.PasswordHash;
        userss.UpdatedAt = TimeHelper.GetDateTime();
        var rbResult = await _userRepository.UpdateAsync(id, userss);
        return rbResult > 0;
    }

    public async Task<List<User>> LoginUserWithData(string email, string password)
    {
        //throw new NotImplementedException();
        var user = await _userRepository.GetUserByEmail(email);

        if (user != null)
        {
            bool isPasswordCorrect = PasswordHasher.Verify(password, user.PasswordHash, user.Salt);

            if (isPasswordCorrect)
            {
                List<User> users = new List<User>();
                users.Add(user);
                return users;
            }
        }

        return new List<User>();
    }

    public async Task<IList<User>> LoginUser(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);

        if (user != null)
        {
            bool isPasswordCorrect = PasswordHasher.Verify(password, user.PasswordHash, user.Salt);

            if (isPasswordCorrect)
            {
                //return true;
                List<User> users = new List<User>();
                users.Add(user);
                return users;

            }
        }

        return new List<User>();

    }
}
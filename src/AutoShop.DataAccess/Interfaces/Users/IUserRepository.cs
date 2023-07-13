using AutoShop.DataAccess.Common.Interfaces;
using AutoShop.DataAccess.ViewModels.Users;
using AutoShop.Domain.Entities.Users;

namespace AutoShop.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, User>, IGetAll<User>, ISearchable<User>
{
    public Task<UserViewModel> GetUserAsync(long id);
}

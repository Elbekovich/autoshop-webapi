using AutoShop.DataAccess.Common.Interfaces;
using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Cars;
using AutoShop.Domain.Entities.Users;

namespace AutoShop.DataAccess.Interfaces.Cars;


public interface ICarRepository : IRepository<Car, Car>, IGetAll<Car>, ISearchable<Car>
{
    public Task<IList<Car>> SearchAsync(string search, PaginationParams @params);
    public Task<int> SearchCountAsync(string search);

    //bu mashinalarni categoryga bo'lishga yordam beradi 
    public Task<IList<Car>> GetCarsByCategory(string category);

    //Task<User> GetByIdAsync(long id);
    


}
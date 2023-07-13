using AutoShop.DataAccess.Common.Interfaces;
using AutoShop.Domain.Entities.Cars;

namespace AutoShop.DataAccess.Interfaces.Cars;


public interface ICarRepository : IRepository<Car, Car>, IGetAll<Car>, ISearchable<Car>
{

}
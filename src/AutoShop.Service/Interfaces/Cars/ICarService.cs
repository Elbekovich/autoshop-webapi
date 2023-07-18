using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Cars;
using AutoShop.Service.Dtos.Cars;

namespace AutoShop.Service.Interfaces.Cars
{
    public interface ICarService
    {
        public Task<bool> CreateAsync(CarCreateDto dto);

        public Task<bool> DeleteAsync(long carId);

        public Task<long> CountAsync();

        public Task<IList<Car>> GetAllAsync(PaginationParams @params);

        public Task<Car> GetByIdAsync(long carId);

        public Task<bool> UpdateAsync(long  carId, CarUpdateDto dto);

        public Task<IList<Car>> SearchAsync(string search, PaginationParams @params);
        public Task<int> SearchCountAsync(string search);
    }
}

using AutoShop.DataAccess.Interfaces.Cars;
using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Cars;
using AutoShop.Domain.Exceptions.Cars;
using AutoShop.Domain.Exceptions.Categories;
using AutoShop.Service.Common.Helpers;
using AutoShop.Service.Dtos.Cars;
using AutoShop.Service.Interfaces.Cars;
using AutoShop.Service.Interfaces.Common;
using System.Data.Common;

namespace AutoShop.Service.Services.Cars
{
    public class CarService : ICarService
    {
        private ICarRepository _repository;
        private IFileService _fileService;
        public CarService(ICarRepository repository, IFileService fileService)
        {
            this._repository = repository;
            this._fileService = fileService;
        }
        public async Task<long> CountAsync()=>await _repository.CountAsync();
        

        public async Task<bool> CreateAsync(CarCreateDto dto)
        {
            string imagepath = await _fileService.UploadImageAsync(dto.ImagePath);
            Car car = new Car()
            {
                ImagePath = imagepath,
                Category = dto.Category,
                Name = dto.Name,
                Color = dto.Color,
                Type = dto.Type,
                TransmissionIsAutomatic = dto.TransmissionIsAutomatic,
                MadeAt = dto.MadeAt,
                Price = dto.Price,
                Description = dto.Description,
                //carid qoldirb ketildi
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime(),
                Probeg = dto.Probeg,
            };
            var result = await _repository.CreateAsync(car);
            return result > 0;
            
        }

        public async Task<bool> DeleteAsync(long carId)
        {
            Car car = new Car();
            //var car = await _repository.GetByIdAsync(carId);
            car = await _repository.GetByIdAsync(carId);
            if (car is null) throw new CarNotFoundException();

            var result = await _fileService.DeleteImageAsync(car.ImagePath);
            if(result is false) throw new CarNotFoundException();

            var dbresult = await _repository.DeleteAsync(carId);
            return dbresult > 0;
        }

        public async Task<IList<Car>> GetAllAsync(PaginationParams @params)
        {
            var cars = await _repository.GetAllAsync(@params);
            return cars;
        }

        public async Task<Car> GetByIdAsync(long carId)
        {
            var car = await _repository.GetByIdAsync(carId);
            if (car is null) throw new CarNotFoundException();
            else return car;
        }

        public async Task<IList<Car>> SearchAsync(string search, PaginationParams @params)
        {
            //throw new NotImplementedException();
            //var car = await _repository.SearchAsync(search, @params);
            //if (car is null) throw new CarNotFoundException();
            //else return car;
            var cars = await _repository.SearchAsync(search, @params);
            int count = await _repository.SearchCountAsync(search);
            return cars;
            //return (count, cars);

        }

        public Task<int> SearchCountAsync(string search)
        {
            throw new NotImplementedException();
            //var car = _repository.SearchCountAsync(search);

        }

        public async Task<bool> UpdateAsync(long carId, CarUpdateDto dto)
        {
            
            var car = await _repository.GetByIdAsync(carId);
            if (car is null) throw new CarNotFoundException();
            car.Category = dto.Category;
            car.Name = dto.Name;
            car.Color = dto.Color;
            car.Type = dto.Type;
            car.TransmissionIsAutomatic = dto.TransmissionIsAutomatic;
            car.MadeAt = dto.MadeAt;
            car.Price = dto.Price;
            car.Description = dto.Description;   
            car.Probeg = dto.Probeg;
            car.Manzil = dto.Manzil;
            if(dto.ImagePath is not null)
            {
                var deleteRes = await _fileService.DeleteImageAsync(car.ImagePath);
                if (deleteRes is false) throw new ImageNotFoundException();
                string newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);
                car.ImagePath = newImagePath;
            }
            // else category old image have to save
            car.UpdatedAt = TimeHelper.GetDateTime();

            var rbResult = await _repository.UpdateAsync(carId, car);
            return rbResult > 0;
        }
    }
}

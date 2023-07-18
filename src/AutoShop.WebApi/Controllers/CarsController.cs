using AutoShop.DataAccess.Utils;
using AutoShop.Service.Dtos.Cars;
using AutoShop.Service.Interfaces.Cars;
using AutoShop.Service.Validators.Dtos.Cars;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.WebApi.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IWebHostEnvironment _env;
        private ICarService _service;
        private readonly int maxPageSize = 30;

        public CarsController(ICarService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("{carId}")]
        public async Task<IActionResult> GetByIdAsync(long carId)
            => Ok(await _service.GetByIdAsync(carId));




        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery] string search, [FromQuery] int page = 1)
            => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));






        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CarCreateDto dto)
        {
            var createValidator = new CarCreateValidator();
            var result = createValidator.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
            
        }

        [HttpPut("{carId}")]
        public async Task<IActionResult> UpdateAsync(long carId, [FromForm] CarUpdateDto dto)
        {
            var updateValidator = new CarUpdateValidator();
            var result = updateValidator.Validate(dto);
            if (result.IsValid) return Ok(await _service.UpdateAsync(carId, dto));
            else return BadRequest(result.Errors);
        }
        
        [HttpDelete("{carId}")]
        public async Task<IActionResult> DeleteAsync(long carId)
            => Ok(await _service.DeleteAsync(carId));

    }
}

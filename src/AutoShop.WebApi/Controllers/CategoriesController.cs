using AutoShop.DataAccess.Utils;
using AutoShop.Service.Dtos.Categories;
using AutoShop.Service.Interfaces.Categories;
using AutoShop.Service.Validators.Dtos.Categories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IWebHostEnvironment _env;
        private ICategoryService _service;
        private readonly int maxPageSize = 30;

        public CategoriesController(ICategoryService service)
        {
            this._service = service;
        }
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [EnableCors("AllowOrigin")]
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByIdAsync(long categoryId)
            => Ok(await _service.GetByIdAsync(categoryId));

        [EnableCors("AllowOrigin")]
        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        {
            var createValidator = new CategoryCreateValidator();
            var result = createValidator.Validate(dto);
            if(result.IsValid) return Ok(await _service.CreateAsync(dto));  
            else return BadRequest(result.Errors);
        }

        [EnableCors("AllowOrigin")]
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
        {
            var updateValidator = new CategoryUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(categoryId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [EnableCors("AllowOrigin")]
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteAsync(long categoryId)
            => Ok(await _service.DeleteAsync(categoryId));
    }
}
//[EnableCors("AllowOrigin")] shuni qoshib chiqdim 7/16/2023 15:03
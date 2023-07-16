using AutoShop.DataAccess.Utils;
using AutoShop.Service.Dtos.Users;
using AutoShop.Service.Interfaces.Users;
using AutoShop.Service.Validators.Dtos.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.WebApi.Controllers
{
    
    
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService;
        private IWebHostEnvironment _env;
        private readonly int maxPageSize = 30;
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _userService.GetAllAsync(new PaginationParams(page, maxPageSize)));
        //{
        //    var response = Ok(await _userService.GetAllAsync(new PaginationParams(page, maxPageSize)));

        //    // Set the 'Access-Control-Allow-Origin' headerobs
        //    Response.Headers.Add("Access-Control-Allow-Origin", "*");

        //    return response;

        //}

        [EnableCors("AllowOrigin")]
        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _userService.CountAsync());

        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto userCreateDto)
        {
            var createValidator = new UserCreateValidator();
            var result = createValidator.Validate(userCreateDto);
            if (result.IsValid) return Ok(await _userService.CreateAsync(userCreateDto));
            else return BadRequest(result.Errors);
        }
        //=> Ok(await _userService.CreateAsync(userCreateDto));
        [EnableCors("AllowOrigin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _userService.DeleteAsync(id));

        [EnableCors("AllowOrigin")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] UserUpdateDto userUpdateDto)
        {
            var updateValidator = new UserUpdateValidator();
            //var validationResult = updateValidator.Validate(dto);
            var vrResult = updateValidator.Validate(userUpdateDto);
            //if (validationResult.IsValid) return Ok(await _service.UpdateAsync(categoryId, dto));
            if (vrResult.IsValid) return Ok(await _userService.UpdateAsync(id, userUpdateDto));
            else return BadRequest(vrResult.Errors);
            //else return BadRequest(validationResult.Errors);
        }
            //=> Ok(await _userService.UpdateAsync(id, userUpdateDto));
        //=> Ok(await _userService.UpdateAsync(categoryId, userCreateDto));

        //[HttpGet]
        //public async Task<IActionResult> CountAsync()
        //=> Ok(await _userService.CountAsync());
    }
}
//[EnableCors("AllowOrigin")] shuni qoshib chiqdim 7/16/2023 15:03
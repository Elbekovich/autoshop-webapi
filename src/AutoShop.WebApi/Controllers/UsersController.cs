using AutoShop.DataAccess.Interfaces.Users;
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
        private readonly IUserRepository _userRepository;
        IUserService _userService;
        private IWebHostEnvironment _env;
        private readonly int maxPageSize = 30;
        public UsersController(IUserService userService, IUserRepository userRepository)
        {
            this._userService = userService;
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _userService.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _userService.CountAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto userCreateDto)
        {
            var createValidator = new UserCreateValidator();
            var result = createValidator.Validate(userCreateDto);
            if (result.IsValid) return Ok(await _userService.CreateAsync(userCreateDto));
            else return BadRequest(result.Errors);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _userService.DeleteAsync(id));

        //[EnableCors("AllowOrigin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] UserUpdateDto userUpdateDto)
        {
            var updateValidator = new UserUpdateValidator();
            var vrResult = updateValidator.Validate(userUpdateDto);
            if (vrResult.IsValid) return Ok(await _userService.UpdateAsync(id, userUpdateDto));
            else return BadRequest(vrResult.Errors);
        }


        [HttpGet("Login")]
        public async Task<IActionResult> LoginUser(string username, string password)=>
            Ok(await _userService.LoginUser(username, password));


        [HttpGet("{userId}/cars")]
        public async Task<IActionResult> GetCarsByUserId(long userId)
        {
            try
            {
                var cars = await _userRepository.GetUserCarsAsync(userId);

                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving cars for user with ID {userId}: {ex.Message}");
            }
        }

    }
}

using Demo_Practice.Interfaces;
using Demo_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetUser/userId")]
        public async Task<ActionResult<List<User>>> GetUserById(int userId)
        {
            try
            {
                var member = await _userService.GetUserById(userId);
                return Ok(member);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [Route("AddUser")]
        [HttpPost]

        public async Task<ActionResult<User>> AddFlight(User user)
        {
            try
            {
                user = await _userService.AddUser(user);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {

            try
            {
                var _member = await _userService.Updateuser(user);
                return _member;
            }
            catch (Exception ex)

            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<User>> RemoveUser(int userId)
        {
            try
            {
                var result = await _userService.RemoveUser(userId);
                return result;
            }
            catch (Exception ex)

            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [Route("Login")]
        [HttpPost]

        public async Task<ActionResult<User>> LoginUser(string username, string password)
        {
            try
            {
                var user = await _userService.LoginUser(username, password);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }
    }
}

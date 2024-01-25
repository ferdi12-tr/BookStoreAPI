using BookStoreWebAPI.Models;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookStoreWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }
        [HttpGet]
        [Route("GetAllUser")]
        public ActionResult<IEnumerable<User>> GetAllUser() 
        {
            try
            {
                var users = userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception e)
            {
                logger.LogError($"UserController ----- GetAllUsers ----- {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                var user = userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                logger.LogError($"UserController ----- GetUserById ----- {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user) 
        {
            try
            {
                await userService.AddUserAsync(user);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                logger.LogError($"UserController ----- AddUser ----- {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

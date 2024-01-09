using BookStoreWebAPI.Models;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

		[HttpPost("LoginUser")]
		public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
		{
			var result = await authService.LoginUserAsync(request);
			return result;
		}
    }
}

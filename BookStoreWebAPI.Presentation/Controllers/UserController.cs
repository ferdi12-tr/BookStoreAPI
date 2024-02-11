using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Presentation.Controllers
{
	[Route("api/v2/users")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IServiceManager _service;

		public UserController(IServiceManager service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult GetUsers()
		{
			try
			{
				var users = _service.UserService.GetAllUsers(trackChanges: false);
				return Ok(users);
			}
			catch
			{
				return StatusCode(500, "Internal server error.");
			}
		}
	}
}

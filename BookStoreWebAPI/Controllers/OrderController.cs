using BookStoreWebAPI.DTOs;
using BookStoreWebAPI.Models;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	[Authorize]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService orderService;
		private readonly ILogger logger;

		public OrderController(IOrderService orderService, ILogger<OrderController> logger)
		{
			this.orderService = orderService;
			this.logger = logger;
		}

		[HttpPost]
		[Route("AddOrder")]
		public async Task<IActionResult> AddOrder([FromBody] OrderDTO order)
		{
			if (order == null)
			{
				return BadRequest("Order is null");
			}

			try
			{
				await orderService.AddOrderAsync(order);
				return Ok("Order Added Successfully");
			}
			catch (Exception e)
			{
				logger.LogError($"OrderController ----- AddOrder ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost]
		[Route("UpdateOrder")]
		public async Task<IActionResult> UpdateOrder([FromBody] OrderDTO order)
		{
			if (order == null)
			{
				return BadRequest("Order is null");
			}

			try
			{
				await orderService.UpdateOrderAsync(order);
				return Ok("Update Order Successfully");
			}
			catch (Exception e)
			{
				logger.LogError($"OrderController ----- AddOrder ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet]
		[Route("GetOrder/{userId}")]
		public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders(int userId = 0)
		{
			if (userId == 0)
			{
				return BadRequest("Id is not valid");
			}

			try
			{
				var orderList = await orderService.GetOrdersByUserIdAsync(userId);
				return Ok(orderList);
			}
			catch (Exception e)
			{
				logger.LogError($"OrderController ----- GetOrder ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost]
		[Route("AddAddress")]
		public async Task<ActionResult<Address>> AddAddress(Address address)
		{
			if (address == null)
			{
				return BadRequest("Address is not Valid");
			}
			
			try
			{
				var checkAddress = await orderService.AddAddressAsync(address);
				return Ok(checkAddress);
			}
			catch (Exception e)
			{
				logger.LogError($"OrderController ----- AddAddress ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet]
		[Route("GetAddress/{userId}")]
		public async Task<ActionResult<Address>> GetAddressByUserId(int userId)
		{
			if (userId == 0)
			{
				return BadRequest("Id is not valid");
			}

			try
			{
				var address = await orderService.GetAddressByUserIdAsync(userId);
				return Ok(address);
			}
			catch (Exception e)
			{
				logger.LogError($"OrderController ----- GetAddressByUserId ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPut]
		[Route("UpdateAddress")]
		public async Task<IActionResult> UpdateAddress([FromBody] Address address)
		{
			try
			{
				await orderService.UpdateAddressAsync(address);
				return Ok();
			}
			catch (Exception e)
			{
				logger.LogError($"OrderController ----- UpdateAddress ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}
	}
}

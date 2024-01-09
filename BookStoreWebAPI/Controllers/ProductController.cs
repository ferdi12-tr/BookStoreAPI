using BookStoreWebAPI.DTOs;
using BookStoreWebAPI.Models;
using BookStoreWebAPI.Models.Interfaces;
using BookStoreWebAPI.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;
		private readonly ILogger logger;
		public ProductController(IProductService productService, ILogger<ProductController> logger)
		{
			this.productService = productService;
			this.logger = logger;
		}

		#region Products

		[HttpGet]
		[Route("AllProducts")]
		[Authorize]
		public IEnumerable<ProductDetailDTO> GetAllProducts()
		{
			var products = productService.GetAllProducts();
			return products;
		}

		[HttpGet]
		[Route("Product/{productId}")]
		public ActionResult<Product> GetProductById(int productId = 0) 
		{
			if (productId == 0)
			{
				return BadRequest("No Product ID");
			}
			try
			{
				var product = productService.GetProductById(productId);
				return Ok(product);
			}
			catch (Exception e)
			{
				logger.LogError($"ProductController ----- GetProductById ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost]
		[Route("AddProduct")]
		public IActionResult AddProduct([FromBody] ProductDetailDTO product)
		{
			if (product == null)
			{
				return BadRequest("No Product Added");
			}
			try
			{
				productService.AddProduct(product);
				return Ok("Add Product Successfully.");
			}
			catch (Exception e)
			{
				logger.LogError($"ProductController ----- AddProduct ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}
		#endregion


		#region Category

		[HttpGet]
		[Route("AllCategories")]
		public List<Category>? GetAllCategories()
		{
			var categoryList = productService.GetAllCategory();
			return categoryList;
		}
		#endregion
	}
}

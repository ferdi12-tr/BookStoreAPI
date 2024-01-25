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
		public async Task<IEnumerable<ProductDetailDTO>> GetAllProducts()
		{
			var products = await productService.GetAllProductsAsync();
			return products;
		}

		[HttpGet]
		[Route("Product/{productId}")]
		public async Task<ActionResult<Product>> GetProductById(int productId = 0) 
		{
			if (productId == 0)
			{
				return BadRequest("No Product ID");
			}
			try
			{
				var product = await productService.GetProductByIdAsync(productId);
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
		public async Task<IActionResult> AddProduct([FromBody] ProductDetailDTO product)
		{
			if (product == null)
			{
				return BadRequest("No Product Added");
			}
			try
			{
				await productService.AddProductAsync(product);
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
		public async Task<List<Category>?> GetAllCategories()
		{
			var categoryList = await productService.GetAllCategoryAsync();
			return categoryList;
		}
		#endregion
	}
}

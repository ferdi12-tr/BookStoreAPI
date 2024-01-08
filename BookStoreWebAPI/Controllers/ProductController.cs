using BookStoreWebAPI.Models;
using BookStoreWebAPI.Models.Interfaces;
using BookStoreWebAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

		#region Products

		[HttpGet]
		[Route("AllProducts")]
		public IEnumerable<Product> GetAllProducts()
		{
			var products = productService.GetAllProducts();
			return products;
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

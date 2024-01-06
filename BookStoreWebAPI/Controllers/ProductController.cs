using BookStoreWebAPI.Models;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
		public IEnumerable<Product> GetAllProducts()
		{
			var products = productService.GetAllProducts();
			return products;
		}
	}
}

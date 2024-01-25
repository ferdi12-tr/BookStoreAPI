using BookStoreWebAPI.DTOs;

namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IProductService
	{
		public Task<List<ProductDetailDTO>> GetAllProductsAsync();
		public Task<ProductDetailDTO> GetProductByIdAsync(int id);

		public Task<bool> AddProductAsync(ProductDetailDTO product);
		public Task<List<Category>?> GetAllCategoryAsync();
	}
}

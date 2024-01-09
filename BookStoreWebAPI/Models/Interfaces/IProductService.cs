using BookStoreWebAPI.DTOs;

namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IProductService
	{
		public List<ProductDetailDTO> GetAllProducts();
		public ProductDetailDTO GetProductById(int id);

		public bool AddProduct(ProductDetailDTO product);
		public List<Category>? GetAllCategory();
	}
}

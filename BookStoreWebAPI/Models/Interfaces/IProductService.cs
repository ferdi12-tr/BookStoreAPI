using BookStoreWebAPI.DTOs;
namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IProductService
	{
		public List<ProductDetailDTO> GetAllProducts();
	}
}

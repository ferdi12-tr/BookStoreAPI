namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IProductService
	{
		public List<Product> GetAllProducts();
		public List<Category>? GetAllCategory();
	}
}

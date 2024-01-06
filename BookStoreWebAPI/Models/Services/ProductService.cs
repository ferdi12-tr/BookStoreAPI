using BookStoreWebAPI.DTOs;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Models.Services
{
	public class ProductService : IProductService
	{
		private readonly DataContext dataContext;

        public ProductService()
        {
            dataContext = new DataContext();
        }
        public List<ProductDetailDTO> GetAllProducts()
		{
			try
			{
				var productList = dataContext.Product?
									.Where(x => x.Stock > 0)
									.Include(y => y.Author)
									.Include(z => z.Category)
									.Select(product => new ProductDetailDTO
									{
										Id = product.Id,
										Name = product.Name,
										Description = product.Description,
										Price = product.Price,
										Stock = product.Stock,
										Image = product.Image,
										Date = product.Date,
										IsMostViewed = product.IsMostViewed,
										IsNewArrival = product.IsNewArrival,
										IsNewFeatured = product.IsNewFeatured,
										Slug = product.Slug,
										CategoryName = product.Category.Name,
										AuthorFullName = product.Author.FullName,

									})
									.ToList();
				return productList;
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
	}
}

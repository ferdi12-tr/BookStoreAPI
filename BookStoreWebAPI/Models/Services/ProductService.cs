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
        public List<Product> GetAllProducts()
		{
			try
			{
				var productList = dataContext.Product?
									.Where(x => x.Stock > 0)
									.Include(y => y.Author)
									.Include(z => z.Category)
									.Select(pr => new Product
									{
										Id = pr.Id,
										Name = pr.Name,
										Description = pr.Description,
										Price = pr.Price,
										Stock = pr.Stock,
										Image = pr.Image,
										Date = pr.Date,
										IsMostViewed = pr.IsMostViewed,
										IsNewArrival = pr.IsNewArrival,
										IsNewFeatured = pr.IsNewFeatured,
										Slug = pr.Slug,
										CategoryId = pr.CategoryId,
										Category = pr.Category,
										AuthorId = pr.AuthorId,
										Author = pr.Author
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

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
									.Select(pr => new ProductDetailDTO
									{
										ProductId = pr.Id,
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
										AuthorId = pr.AuthorId,
									})
									.ToList();
				return productList;
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
		public ProductDetailDTO GetProductById(int id)
		{
			try
			{
				var product = dataContext.Product?
					.Where(x => x.Id == id)
					.Include(a => a.Author)
					.Include(c => c.Category)
					.Select(pr => new ProductDetailDTO
					{
						ProductId = pr.Id,
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
						AuthorId = pr.AuthorId,

					})
					.FirstOrDefault();
				return product;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public bool AddProduct(ProductDetailDTO product)
		{
			var newProduct = new Product
			{
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Stock = product.Stock,
				Image = product.Image,
				Date = product.Date,
				IsMostViewed = product.IsMostViewed,
				IsNewArrival = product.IsNewArrival,
				IsNewFeatured = product.IsNewFeatured,
				Slug = Utils.Utils.CenerateSlug(product.Name),
				CategoryId = product.CategoryId,
				AuthorId = product.AuthorId,
			};
			try
			{
				dataContext.Product?.Add(newProduct);
				dataContext.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public List<Category>? GetAllCategory()
		{
			var categoryList = dataContext.Category?.Include(x => x.Products).ToList();
			return categoryList;
		}
	}
}

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
        public async Task<List<ProductDetailDTO>> GetAllProductsAsync()
		{
			try
			{
				var productList = await dataContext.Product
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
										AuthorName = pr.Author.FullName,
										CategoryId = pr.CategoryId,
										AuthorId = pr.AuthorId,
									})
									.ToListAsync();
				return productList;
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
		public async Task<ProductDetailDTO> GetProductByIdAsync(int id)
		{
			try
			{
				var product = await dataContext.Product
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
					.FirstOrDefaultAsync();
				return product;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<bool> AddProductAsync(ProductDetailDTO product)
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
				await dataContext.SaveChangesAsync();
				return true;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public async Task<List<Category>?> GetAllCategoryAsync()
		{
			var categoryList = await dataContext.Category.Include(x => x.Products).ToListAsync();
			return categoryList;
		}
	}
}

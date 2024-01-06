using BookStoreWebAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Models.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly DataContext dataContext;
        public CategoryService()
        {
			this.dataContext = new DataContext();
        }
        public List<Category>? GetAllCategory()
		{
			var categoryList = dataContext.Category?.Include(x => x.Products).ToList();
			return categoryList;
		}
	}
}

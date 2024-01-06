using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Models.Interfaces
{
	public interface ICategoryService
	{
		public List<Category>? GetAllCategory();
	}
}

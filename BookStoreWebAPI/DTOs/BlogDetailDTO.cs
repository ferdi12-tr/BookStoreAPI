using BookStoreWebAPI.Models;

namespace BookStoreWebAPI.DTOs
{
	public class BlogDetailDTO
	{
		public int BlogId { get; set; }
		public string? Title { get; set; }
		public string? BlogContent { get; set; }
		public int AuthorId { get; set; }
		public string? Slug { get; set; }
		public DateTime Date { get; set; }
	}
}

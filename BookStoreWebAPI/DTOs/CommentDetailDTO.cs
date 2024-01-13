using BookStoreWebAPI.Models;

namespace BookStoreWebAPI.DTOs
{
	public class CommentDetailDTO
	{
		public string? BlogComment { get; set; }
		public DateTime? Date { get; set; }
		public string? AuthorName { get; set; }
		public int UserId { get; set; }
        public int BlogId { get; set; }
	}
}

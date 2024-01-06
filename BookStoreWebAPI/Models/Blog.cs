namespace BookStoreWebAPI.Models
{
	public class Blog
	{
		public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public User? Author { get; set; }
        public DateTime Date { get; set; }
		public List<Comment>? Comments { get; set; }
	}
}

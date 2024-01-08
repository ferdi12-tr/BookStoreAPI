namespace BookStoreWebAPI.Models
{
	public class Blog
	{
		public int Id { get; set; }
        public string? Title { get; set; }
        public string? BlogContent { get; set; }
        public int BlogCreatorId { get; set; }
        public User? Author { get; set; }
        public DateTime Date { get; set; }
		public List<Comment>? Comments { get; set; }
	}
}

namespace Entities.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public DateTime Date { get; set; }
        public bool IsNewArrival { get; set; }
        public bool IsNewFeatured { get; set; }
        public bool IsMostViewed { get; set; }
        public string? Slug { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

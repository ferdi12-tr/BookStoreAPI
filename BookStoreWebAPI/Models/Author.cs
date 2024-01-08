using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebAPI.Models
{
	public class Author
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [NotMapped]
        public string? FullName { get =>  Name + Surname; }
        public List<Product>? Products { get; set; }
    }
}

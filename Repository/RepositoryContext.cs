using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class RepositoryContext : DbContext
	{
        public RepositoryContext(DbContextOptions options) : base(options)
        {
                
        }


		public DbSet<User>? User { get; set; }
		public DbSet<Address>? Address { get; set; }
		public DbSet<Category>? Category { get; set; }
		public DbSet<Author>? Author { get; set; }
		public DbSet<Product>? Product { get; set; }
		public DbSet<Order>? Order { get; set; }
		public DbSet<Blog>? Blog { get; set; }
		public DbSet<Comment>? Comment { get; set; }

	}
}

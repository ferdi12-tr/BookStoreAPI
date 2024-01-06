using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Models
{
	public class DataContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-H100B8S;
											Initial Catalog=BookStoreDB;
											Integrated Security=True;
											Trust Server Certificate=True");
		}


		public DbSet<User>? User { get; set; }
		public DbSet<Category>? Category { get; set; }
		public DbSet<Product>? Product { get; set; }
		public DbSet<Blog>? Blog { get; set; }
		public DbSet<Comment>? Comment { get; set; }

	}
}

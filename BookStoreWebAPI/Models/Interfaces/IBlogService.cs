using BookStoreWebAPI.DTOs;

namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IBlogService
	{
		public Task<List<BlogDetailDTO>?> GetAllBlogPostsAsync();

		public Task<List<CommentDetailDTO>?> GetCommentByBlogIdAsync(int id);	
		public Task AddBlogPostAsync(BlogDetailDTO post);
		public Task<bool> AddCommentAsync(CommentDetailDTO comment);
	}
}

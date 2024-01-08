using BookStoreWebAPI.DTOs;

namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IBlogService
	{
		public List<BlogDetailDTO>? GetAllBlogPosts();

		public List<CommentDetailDTO>? GetCommentByBlogId(int id);	
		public void AddBlogPost(BlogDetailDTO post);
		public bool AddComment(CommentDetailDTO comment);
	}
}

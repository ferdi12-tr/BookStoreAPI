using BookStoreWebAPI.DTOs;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Models.Services
{
	public class BlogService : IBlogService
	{
		private readonly DataContext dataContext;

        public BlogService()
        {
            dataContext = new DataContext();
        }

		public void AddBlogPost(BlogDetailDTO post)
		{
			var newBlog = new Blog
			{
				Title = post.Title,
				Image=post.Image,
				BlogContent = post.BlogContent,
				AuthorId = post.AuthorId,
				Slug = Utils.Utils.CenerateSlug(post.Title),
				Date = post.Date
			};
			try
			{
				dataContext.Blog?.Add(newBlog);
				dataContext.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public bool AddComment(CommentDetailDTO comment)
		{
			var newComment = new Comment
			{
				BlogComment = comment.BlogComment,
				Date = comment.Date,
				UserId = comment.UserId,
				BlogId = comment.BlogId,
			};

			try
			{
				dataContext.Comment.Add(newComment);
				dataContext.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public List<BlogDetailDTO>? GetAllBlogPosts()
		{
			try
			{
				var blogPosts = dataContext.Blog?
					.Include(x => x.Author)
					.Select(s => new BlogDetailDTO
					{
						BlogId = s.Id,
						Title = s.Title,
						Image = s.Image,
						BlogContent = s.BlogContent,
						Slug = s.Slug,
						AuthorId = s.Author.Id,
						AuthorUserName = s.Author.Username,
						Date = s.Date,
					})
					.ToList();
				return blogPosts;
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
		public List<CommentDetailDTO>? GetCommentByBlogId(int id)
		{
			try
			{
				var comments = dataContext.Comment?
												.Where(x => x.BlogId == id)
												.Include(u => u.User)
												.Select(c => new CommentDetailDTO
												{
													BlogComment = c.BlogComment,
													Date = c.Date,
													AuthorName = c.User.Username,
													UserId = c.UserId,
													BlogId = c.BlogId,	
												})
												.ToList();
				return comments;
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
	}
}

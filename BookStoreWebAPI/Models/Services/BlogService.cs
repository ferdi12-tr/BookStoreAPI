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

		public async Task AddBlogPostAsync(BlogDetailDTO post)
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
				await dataContext.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<bool> AddCommentAsync(CommentDetailDTO comment)
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
				await dataContext.SaveChangesAsync();
				return true;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<List<BlogDetailDTO>?> GetAllBlogPostsAsync()
		{
			try
			{
				var blogPosts = await dataContext.Blog
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
					.ToListAsync();
				return blogPosts;
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
		public async Task<List<CommentDetailDTO>?> GetCommentByBlogIdAsync(int id)
		{
			try
			{
				var comments = await dataContext.Comment
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
												.ToListAsync();
				return comments;
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
	}
}

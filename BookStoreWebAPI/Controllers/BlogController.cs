using BookStoreWebAPI.DTOs;
using BookStoreWebAPI.Models;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
        private readonly IBlogService blogService;
		private readonly ILogger logger;
		public BlogController(IBlogService blogService, ILogger<BlogController> logger)
        {
            this.blogService = blogService; 
			this.logger = logger;
        }

		#region Blogs
		[HttpGet]
		[Route("GetBlogs")]
		public async Task<ActionResult<IEnumerable<BlogDetailDTO>?>> GetAllBlogPosts()
		{
			try
			{
				var allBlog = await blogService.GetAllBlogPostsAsync();
				return Ok(allBlog);
			}
			catch (Exception e)
			{
				logger.LogError($"BlogController ----- GetAllBlogPosts ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost]
		[Route("AddBlog")]
        [Authorize]
        public async Task<IActionResult> AddBlogPost([FromBody] BlogDetailDTO blog)
		{
			if (blog == null)
			{
				return BadRequest("Blog Post is null");
			}
			try
			{
				await blogService.AddBlogPostAsync(blog);
				return Ok("Add Blog Successfully");
			}
			catch (Exception e)
			{
				logger.LogError($"BlogController ----- AddBlog ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}

		}

		#endregion

		#region Comments

		[HttpGet]
		[Route("GetComment/{blogId}")]
        public async Task<ActionResult<IEnumerable<CommentDetailDTO>?>> GetCommentByBlogId(int blogId = 0) 
        {
			if (blogId == 0)
			{
				return BadRequest("No Blog ID");
			}

			try
			{
				var allcomment = await blogService.GetCommentByBlogIdAsync(blogId);
				return Ok(allcomment);
			}
			catch (Exception e)
			{
				logger.LogError($"BlogController ----- GetCommentByBlogId ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
        }

		[HttpPost]
		[Route("AddComment")]
		[Authorize]
		public async Task<IActionResult> AddComment([FromBody] CommentDetailDTO comment)
		{
			if (comment == null)
			{
				return BadRequest("Comment is null");
			}
			
			try
			{
				bool result = await blogService.AddCommentAsync(comment);
				return Ok("Add Comment Successfully");
			}
			catch (Exception e)
			{
				logger.LogError($"BlogController ----- AddComment ----- {e.Message}");
				return StatusCode(500, "Internal server error");
			}
		}
		#endregion
	}
}

using Blog.Application.Repositories;
using Blog.Core.Models;
using Blog.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Blog.Application.AppServices.Blogs;

namespace Blog.Infrastructure.Repositories
{
	public class PostRepository : Repository<Post>, IPostRepository
	{
		private readonly BlogDbContext _context;

		public PostRepository(BlogDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Post> GetAsync(int id)
		{
			return await Entities.FirstOrDefaultAsync(post => post.Id == id);
		}

		public List<PostDto> GetPostsByBlog(int blogId)
		{
			var postsOfBlog = (from posts in _context.Set<Post>()
							   join userBlog in _context.Set<UserBlog>().Where(x => x.Id == blogId) on posts.UserBlogId equals userBlog.Id
							   select new PostDto
							   {
								   Id = posts.Id,
								   Title = posts.Title,
								   UserId = posts.UserId,
								   BlogId = userBlog.Id,
								   PublishDateOnUtc = posts.PublishDateOnUtc,
								   Text = posts.Text
							   }
				   ).ToList();

			foreach (var p in postsOfBlog)
				Console.WriteLine($"{ p.Id } ({ p.Title }) - { p.BlogId } { p.UserId }");

			return postsOfBlog;
		}

		public void GetPostsDataByBlog(int blogId)
		{
			var p = new List<Post>
			{
				new Post { Id = 1, Title = "1Post", UserBlogId = 1, UserId = 1 },
				new Post { Id = 2, Title = "2Post", UserBlogId = 1, UserId = 1 },
				new Post { Id = 3, Title = "3Post", UserBlogId = 2, UserId = 2 }
			};

			var l = new List<LikeInPost>
			{
				new LikeInPost { Id = 1, IsNegative = false, PostId = 1, UserId = 3 },
				new LikeInPost { Id = 2, IsNegative = false, PostId = 1, UserId = 2 },
				new LikeInPost { Id = 3, IsNegative = false, PostId = 1, UserId = 4 },
				new LikeInPost { Id = 4, IsNegative = false, PostId = 2, UserId = 3 },
				new LikeInPost { Id = 5, IsNegative = false, PostId = 3, UserId = 2 },
			};

			var posts = (from post in p
						 join likeInPost in l on post.Id equals likeInPost.PostId
						 where post.UserBlogId == blogId
						 select new
						 {
							 Id = post.Id,
							 Title = post.Title,
							 Text = post.Text,
							 PublishDateOnUtc = post.PublishDateOnUtc,
							 UserId = post.Id,
							 BlogId = post.UserBlogId,
							 IsNegative = likeInPost.IsNegative,
							 likeId = likeInPost.Id,
							 PostId = likeInPost.PostId
						 }).ToList();


			//var posts = (from post in _context.Set<Post>()
			//			join likeInPost in _context.Set<LikeInPost>() on post.Id equals likeInPost.PostId
			//			where post.UserBlogId == blogId
			//			select new { Id = post.Id, Title = post.Title, Text = post.Text, 
			//			PublishDateOnUtc = post.PublishDateOnUtc, UserId = post.Id, BlogId = post.UserBlogId, 
			//			IsNegative = likeInPost.IsNegative, likeId = likeInPost.Id,  PostId = likeInPost.PostId }).ToList();

			foreach (var x in posts)
				Console.WriteLine($"{ x.Id } ,{ x.Title }, { x.Text }, { x.PublishDateOnUtc }, { x.UserId }, { x.BlogId } { x.IsNegative } ,{ x.likeId } , { x.PostId })");
		}
	}
}

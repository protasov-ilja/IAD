using Blog.Application.Repositories;
using Blog.Core.Models;
using Blog.Infrastructure.Foundation;
using Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Blog.Application.AppServices.Blogs;

namespace Blog.Infrastructure.Repositories
{
	public class UserBlogRepository : Repository<UserBlog>, IUserBlogRepository
	{
		private BlogDbContext _context;

		public UserBlogRepository(BlogDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<UserBlog> GetInfoByUserId(int userId)
		{
			return await Entities.FirstOrDefaultAsync(blog => blog.UserId == userId);
		}

		public List<BlogDto> GetSubscribedBlogs(int userId)
		{
			/*
			var s = new List<SubscriberOfBlog>
			{
				new SubscriberOfBlog{ Id = 1, UserBlogId = 1, UserId = 1 },
				new SubscriberOfBlog{ Id = 1, UserBlogId = 2, UserId = 1 },
				new SubscriberOfBlog{ Id = 1, UserBlogId = 3, UserId = 1 },
				new SubscriberOfBlog{ Id = 1, UserBlogId = 1, UserId = 2 }
			};

			var u = new List<User>
			{
				new User{ Id = 1, Login = "1", Password = "123" },
				new User{ Id = 2, Login = "2", Password = "123" }
			};

			var b = new List<UserBlog>
			{
				new UserBlog { Id = 1, Info = "blog 1", Name = "Blog1", UserId = 3 },
				new UserBlog { Id = 2, Info = "blog 2", Name = "Blog2", UserId = 3 },
				new UserBlog { Id = 3, Info = "blog 3", Name = "Blog3", UserId = 3 },
				new UserBlog { Id = 4, Info = "blog 4", Name = "Blog4", UserId = 3 },
				new UserBlog { Id = 5, Info = "blog 5", Name = "Blog5", UserId = 1 }
			};

			var asd = (from subscribe in s
					   join user in u.Where(x => x.Id == id) on subscribe.UserId equals user.Id
					   join userBlog in b on subscribe.UserBlogId equals userBlog.Id
					   select new { userBlog.Id, userBlog.Name, userBlog.Info }).ToList();*/

			var subscribedBlogs = (from subscribe in _context.Set<SubscriberOfBlog>()
								   join user in _context.Set<User>().Where(x => x.Id == userId) on subscribe.UserId equals user.Id
								   join userBlog in _context.Set<UserBlog>() on subscribe.UserBlogId equals userBlog.Id
								   select new BlogDto { Id = userBlog.Id, Name = userBlog.Name, Info = userBlog.Info, ImageUri = user.ImageUri, UserId = userBlog.UserId }
								   ).ToList();

			foreach (var p in subscribedBlogs)
				Console.WriteLine($"{ p.Id } ({ p.Name }) - { p.Info } { p.UserId }");

			return subscribedBlogs;
		}
	}
}

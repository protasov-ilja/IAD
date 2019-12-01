using System.Threading.Tasks;
using Blog.Application.Repositories;
using Blog.Core.Models;
using Blog.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Linq;

namespace Blog.Infrastructure.Repositories
{
	public class SubscribersOfBlogRepository : Repository<SubscriberOfBlog>, ISubscriberOfBlogRepository
	{
		public SubscribersOfBlogRepository(BlogDbContext context) : base(context)
		{
		}

		public async Task<SubscriberOfBlog> GetAsyncByUserIdAndBlogId(int userId, int blogId)
		{
			return await Entities.FirstOrDefaultAsync(subscrition => subscrition.UserBlogId == blogId && subscrition.UserId == userId);
		}
	}
}

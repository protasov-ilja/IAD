using Blog.Core.Models;
using Repositories.Abstractions;
using System.Threading.Tasks;

namespace Blog.Application.Repositories
{
	public interface ISubscriberOfBlogRepository : IRepository<SubscriberOfBlog>
	{
		Task<SubscriberOfBlog> GetAsyncByUserIdAndBlogId(int userId, int blogId);
	}
}

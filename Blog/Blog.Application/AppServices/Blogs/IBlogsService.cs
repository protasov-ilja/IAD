using System.Threading.Tasks;

namespace Blog.Application.AppServices.Blogs
{
	public interface IBlogsService
	{
		Task<BlogsData> GetUserSubscriptions(int userId);
		Task GetBlogData(int blogId, string login);
	}
}

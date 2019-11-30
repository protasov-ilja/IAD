using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Blogs
{
	public interface IBlogsService
	{
		Task<List<int>> GetUserSubscriptions(int userId);
	}
}

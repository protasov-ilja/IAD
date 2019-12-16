using System.Threading.Tasks;

namespace Blog.Application.AppServices.Blogs
{
	public interface IBlogsService
	{
		Task<BlogsData> GetUserSubscriptions(string login);
		Task<BlogsData> GetAllBlogs(string login);
		Task<BlogTotalData> GetBlogData(int blogId, string login);
		Task<BlogTotalData> GetUserBlogData(string login);
		Task<bool> IsUserBlog(int blogId, string login);
		Task<BoolResponseDto> RatePost(RateData rateData);
		Task<BoolResponseDto> UnratePost(RateData rateData);
		Task<BoolResponseDto> CreateBlog(string login);
		Task<BoolResponseDto> CreatePost(PostDto postDto, string login);
		Task<BoolResponseDto> RemovePost(RemovePostDto postId);
	}
}

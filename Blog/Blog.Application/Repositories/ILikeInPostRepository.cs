using Blog.Application.AppServices.Blogs;
using Blog.Core.Models;
using Repositories.Abstractions;
using System.Threading.Tasks;

namespace Blog.Application.Repositories
{
	public interface ILikeInPostRepository : IRepository<LikeInPost>
	{
		Task<LikeInPost> GetAsyncByUserId(int userId);
		LikesOfPostData GetLikesOfPost(int postId, int userId);
	}
}

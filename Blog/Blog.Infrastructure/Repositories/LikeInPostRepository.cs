using Blog.Application.AppServices.Blogs;
using Blog.Application.Repositories;
using Blog.Core.Models;
using Blog.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
	public class LikeInPostRepository : Repository<LikeInPost>, ILikeInPostRepository
	{
		private readonly BlogDbContext _context;

		public LikeInPostRepository(BlogDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<LikeInPost> GetAsyncByUserId(int userId)
		{
			return await Entities.FirstOrDefaultAsync(like => like.UserId == userId);
		}

		public LikesOfPostData GetLikesOfPost(int postId, int userId)
		{
			var likesOfPost = (from like in _context.Set<LikeInPost>().Where(x => x.PostId == postId)
							   select new LikeInPost()).ToList();

			foreach (var l in likesOfPost)
				Console.WriteLine($"{ l.Id } ({ l.PostId }) - { l.IsNegative } { l.UserId }");

			var positiveLikes = likesOfPost.Where(x => !x.IsNegative).ToList();
			var negativeLikes = likesOfPost.Where(x => x.IsNegative).ToList();
			var alradyRated = likesOfPost.Where(x => x.UserId == userId) != null;

			var likesData = new LikesOfPostData { PositiveLikes = positiveLikes.Count, NegativeLikes = negativeLikes.Count, AlreadyRated = alradyRated };

			return likesData;
		}
	}
}

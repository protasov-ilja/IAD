using Blog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Foundation
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UserBlogConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new CommentConfiguration());
			builder.ApplyConfiguration(new LikeInPostConfiguration());
			builder.ApplyConfiguration(new PostConfiguration());
			builder.ApplyConfiguration(new SubscriberOfBlogConfiguration());
		}
	}
}

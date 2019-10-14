using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
	public class SubscriberOfBlogConfiguration : IEntityTypeConfiguration<SubscriberOfBlog>
	{
		public void Configure(EntityTypeBuilder<SubscriberOfBlog> builder)
		{
			builder.ToTable(nameof(SubscriberOfBlog)).HasKey(t => t.Id);

			builder.HasOne<UserBlog>()
				.WithMany()
				.HasForeignKey(b => b.UserBlogId);

			builder.HasOne<User>()
				.WithMany()
				.HasForeignKey(b => b.UserId);
		}
	}
}

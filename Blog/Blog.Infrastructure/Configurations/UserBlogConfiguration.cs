using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
	public class UserBlogConfiguration : IEntityTypeConfiguration<UserBlog>
	{
		public void Configure(EntityTypeBuilder<UserBlog> builder)
		{
			builder.ToTable(nameof(UserBlog)).HasKey(t => t.Id);

			builder.HasOne<User>()
				.WithMany()
				.HasForeignKey(b => b.UserId);
		}
	}
}

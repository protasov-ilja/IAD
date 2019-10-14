using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.ToTable(nameof(Post)).HasKey(t => t.Id);

			builder.HasOne<UserBlog>()
				.WithMany()
				.HasForeignKey(b => b.BlogId);
		}
	}
}

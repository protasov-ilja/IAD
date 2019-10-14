using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
	public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.ToTable(nameof(Comment)).HasKey(t => t.Id);

			builder.HasOne<Post>()
				.WithMany()
				.HasForeignKey(b => b.PostId);

			builder.HasOne<User>()
				.WithMany()
				.HasForeignKey(b => b.UserId);
		}
	}
}

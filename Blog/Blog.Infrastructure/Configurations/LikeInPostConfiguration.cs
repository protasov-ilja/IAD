using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
	public class LikeInPostConfiguration : IEntityTypeConfiguration<LikeInPost>
	{
		public void Configure(EntityTypeBuilder<LikeInPost> builder)
		{
			builder.ToTable(nameof(LikeInPost)).HasKey(t => t.Id);
			
			builder.HasOne<Post>()
				.WithMany()
				.HasForeignKey(b => b.PostId).OnDelete(DeleteBehavior.Restrict);

			builder.HasOne<User>()
				.WithMany()
				.HasForeignKey(b => b.UserId);
		}
	}
}
namespace Blog.Core.Models
{
	public class LikeInPost
	{
		public int Id { get; set; }
		public int PostId { get; set; }
		public int UserId { get; set; }
		public bool IsNegative { get; set; }
	}
}

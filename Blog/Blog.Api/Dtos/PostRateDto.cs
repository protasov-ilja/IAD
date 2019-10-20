namespace Blog.Api.Dtos
{
	public class PostRateDto
	{
		public int SenderId{ get; set; }
		public int BlogId { get; set; }
		public int PostId { get; set; }
		public bool IsNegative { get; set; }
	}
}

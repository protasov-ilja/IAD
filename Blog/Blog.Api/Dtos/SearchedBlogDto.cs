namespace Blog.Api.Dtos
{
	public class SearchedBlogDto
	{
		public int BlogId { get; set; }
		public string BlogName { get; set; }
		public string BlogInfo { get; set; }
		public bool AlreadySubscribed { get; set; }
		public string BlogImageUri { get; set; }
	}
}

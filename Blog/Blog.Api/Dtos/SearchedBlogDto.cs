namespace Blog.Api.Dtos
{
	public class SearchedBlogDto
	{
		public int BlogId { get; set; }
		public string BlogName { get; set; }
		public string BlogInfotext { get; set; }
		public bool AlreadySubscribed { get; set; }
		public string BlogImageUri { get; set; }
	}
}

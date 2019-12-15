
namespace Blog.Application.AppServices.Blogs
{
	public struct RateData
	{
		public string Login { get; set; }
		public int BlogId { get; set; }
		public int PostId { get; set; }
		public bool IsNegative { get; set; }
	}
}

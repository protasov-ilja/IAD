namespace Blog.Application.AppServices.Blogs
{
	public struct LikesOfPostData
	{
		public int PositiveLikes { get; set; }
		public int NegativeLikes { get; set; }
		public bool AlreadyRated { get; set; }
	}
}

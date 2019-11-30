namespace Blog.Core.Models
{
	public class UserBlog
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public int UserId { get; set; }

		public UserBlog(int userId, string name, string info)
		{
			UserId = userId;
			Info = info;
			Name = name;
		}
	}
}

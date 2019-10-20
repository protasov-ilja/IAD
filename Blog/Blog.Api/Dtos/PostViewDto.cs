using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Dtos
{
	public class PostViewDto
	{
		public int PostId { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public string BlogName { get; set; }
		public int BlogId { get; set; }
		public int LikesAmount { get; set; }
		public int DislikesAmount { get; set; }
		public DateTime? PublishDateInUtc { get; set; }
	}
}

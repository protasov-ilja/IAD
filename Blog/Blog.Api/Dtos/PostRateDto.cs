﻿namespace Blog.Api.Dtos
{
	public class PostRateDto
	{
		public int BlogId { get; set; }
		public int PostId { get; set; }
		public bool IsNegative { get; set; }
	}
}

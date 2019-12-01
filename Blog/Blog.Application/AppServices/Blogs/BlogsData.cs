using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.AppServices.Blogs
{
	public struct BlogsData
	{
		public bool IsSuccessCreated { get; set; }
		public string ErrorInfo { get; set; }
		public List<BlogDto> Blogs { get; set; }
	}
}

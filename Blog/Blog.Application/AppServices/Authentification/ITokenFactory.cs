using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.AppServices.Authentification
{
	public interface ITokenFactory
	{
		string GenerateToken(int size = 32);
	}
}

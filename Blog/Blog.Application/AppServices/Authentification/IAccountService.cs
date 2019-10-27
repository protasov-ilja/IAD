using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Authentification
{
	public interface IAccountService
	{
		Task<string> Authentificate(string login, string password);
		Task<string> UpdateAccessToken(string refreshToken);
		Task<string> RegisterUser(string login, string password, string firstName, string lastName);
	}
}

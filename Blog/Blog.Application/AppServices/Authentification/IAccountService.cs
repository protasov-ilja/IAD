using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Authentification
{
	public interface IAccountService
	{
		Task<TokensData> Authentificate(string login, string password);
		Task<TokensData> UpdateAccessToken(string refreshToken);
		Task<TokensData> RegisterUser(string login, string password, string firstName, string lastName);
	}
}

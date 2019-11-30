using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Application.AppServices.Authentification.Key
{
	public class AuthOptions
	{
		public const string Issuer = "Blog.Api";
		public const string Audience = "BlogFrontend"; // aplication address
		private const string Key = "mysupersecret_sceretkey!123"; // salt
		public const int LifeTime = 3;

		public static SymmetricSecurityKey GetSymmetricSceurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
		}
	}
}

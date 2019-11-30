using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Api.Dtos
{
	public class AuthOptions
	{
		public const string Issuer = "MyAuthServer";
		public const string Audience = "https://localhost:5001/"; // aplication address
		private const string Key = "mysupersecret_sceretkey!123"; // salt
		public const int LifeTime = 1;
		public static SymmetricSecurityKey GetSymmetricSceurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
		}
	}
}

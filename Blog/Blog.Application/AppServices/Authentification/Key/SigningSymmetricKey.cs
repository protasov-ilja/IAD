using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Application.AppServices.Authentification.Key
{
	public class SigningSymmetricKey : IJwtSigningEncodingKey, IJWtSigningDecodingKey 
	{
		private readonly SymmetricSecurityKey _secretKey;

		public string SigningAlgorithm { get; } = SecurityAlgorithms.HmacSha256;

		public SigningSymmetricKey(string key)
		{
			_secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
		}

		public SecurityKey GetDecodingKey() => _secretKey;

		public SecurityKey GetEncodingKey() => _secretKey;
	}
}

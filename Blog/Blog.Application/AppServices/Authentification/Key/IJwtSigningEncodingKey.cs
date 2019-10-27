using Microsoft.IdentityModel.Tokens;

namespace Blog.Application.AppServices.Authentification
{
	// Ключ для создания подписи (приватный)
	public interface IJwtSigningEncodingKey
	{
		string SigningAlgorithm { get; }
		SecurityKey GetEncodingKey();
	}
}

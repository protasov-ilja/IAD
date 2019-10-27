using Microsoft.IdentityModel.Tokens;

namespace Blog.Application.AppServices.Authentification.Key
{
	// Ключ для проверки подписи (публичный)
	public interface IJWtSigningDecodingKey
	{
		SecurityKey GetDecodingKey();
	}
}

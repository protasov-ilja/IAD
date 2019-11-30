using Blog.Application.AppServices.Authentification.Key;
using Blog.Application.Repositories;
using Blog.Core.Models;
using Microsoft.IdentityModel.Tokens;
using Repositories.Abstractions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Authentification
{
	public class AccountService : IAccountService
	{
		private readonly IUserRepository _userRepository;
		private readonly IJwtSigningEncodingKey _signingEncodingKey;
		private readonly IUnitOfWork _unitOfWork;

		public AccountService(IUserRepository userRepository, IJwtSigningEncodingKey signingEncodingkey, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_signingEncodingKey = signingEncodingkey;
			_userRepository = userRepository;
		}

		public async Task<TokensData> Authentificate(string login, string password)
		{
			var user = await _userRepository.GetAsync(login);

			if (user == null)
			{
				return new TokensData
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such user not found!"
				};
			}

			string accessToken = GetAccessToken(login, password);
			string refreshToken = GetRefreshToken(login, password);

			user.RefreshToken = refreshToken;
			await _unitOfWork.CommitAsync();

			return new TokensData
			{
				IsSuccessCreated = true,
				AccessToken = accessToken,
				RefreshToken = $"{ user.Id }|{ refreshToken }"
			};
		}

		public async Task<TokensData> UpdateAccessToken(string refreshToken)
		{
			var tokenData = refreshToken.Split('|');
			var token = tokenData[1];
			var userId = tokenData[0];

			int id = -1;
			if (!int.TryParse(userId, out id))
			{
				return new TokensData
				{
					IsSuccessCreated = false,
					ErrorInfo = "such user in refresh token not found!"
				};
			}

			User user = await _userRepository.GetAsync(id);
			if (user == null)
			{
				return new TokensData
				{
					IsSuccessCreated = false,
					ErrorInfo = "such user in refresh token not found!"
				};
			}

			if (token != user.RefreshToken)
			{
				return new TokensData
				{
					IsSuccessCreated = false,
					ErrorInfo = "such refresh token not valid!"
				};
			}

			string accessToken = GetAccessToken(user.Login, user.Password);
			string newRefreshToken = GetRefreshToken(user.Login, user.Password);

			user.RefreshToken = newRefreshToken;
			await _unitOfWork.CommitAsync();

			return new TokensData
			{
				IsSuccessCreated = true,
				AccessToken = accessToken,
				RefreshToken = $"{ user.Id }|{ newRefreshToken }"
			};
		}

		public async Task<TokensData> RegisterUser(string login, string password, string firstName, string lastName)
		{
			var user = await _userRepository.GetAsync(login);

			if (user != null)
			{
				return new TokensData { 
					IsSuccessCreated = false,
					ErrorInfo = "error such user already created!"
				};
			}

			user = new User(login, password, firstName, lastName);
			_userRepository.Add(user);

			string accessToken = GetAccessToken(login, password);
			string refreshToken = GetRefreshToken(login, password);

			user.RefreshToken = refreshToken;
			await _unitOfWork.CommitAsync();

			return new TokensData
			{
				IsSuccessCreated = true,
				AccessToken = accessToken,
				RefreshToken = $"{ user.Id }|{ refreshToken }"
			};
		}

		private string GetRefreshToken(string login, string password)
		{
			return Guid.NewGuid().ToString();
		}

		private string GetAccessToken(string login, string password)
		{
			// 2. Создаем утверждение для токена
			var claims = new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, login)
			};

			// Generate JWT
			var token = new JwtSecurityToken(
				issuer: AuthOptions.Issuer,
				audience: AuthOptions.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(AuthOptions.LifeTime),
				signingCredentials: new SigningCredentials(
					_signingEncodingKey.GetEncodingKey(),
					_signingEncodingKey.SigningAlgorithm)
			);

			string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

			return jwtToken;
		}
	}
}
